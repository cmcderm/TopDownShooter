using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (LineRenderer))]
public class Handgun : Gun {

	LineRenderer _line;

	private float trailTimeout = 2f;
	private float timeSinceFire = 0f;

	[SerializeField]
	private int damage = 5;

	// Use this for initialization
	void Start () {
		_line = GetComponent<LineRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (timeSinceFire < trailTimeout) {
			timeSinceFire += Time.deltaTime;
			_line.startColor = new Color (_line.startColor.r, _line.startColor.g, _line.startColor.b, (timeSinceFire / Time.deltaTime) * 255f);
			_line.endColor = new Color (_line.endColor.r, _line.endColor.g, _line.endColor.b, (timeSinceFire / Time.deltaTime) * 255f);
		}
	}

	override public void Fire () {
		Debug.Log ("Fire!");

		RaycastHit2D hit = Physics2D.Raycast (EndOfBarrel.transform.position, EndOfBarrel.transform.right, 100f);
		//Debug.DrawLine(EndOfBarrel.transform.position, hit.point);
		_line.positionCount = 2;
		_line.SetPosition (0, new Vector3 (EndOfBarrel.transform.position.x, EndOfBarrel.transform.position.y, -1));
		_line.SetPosition (1, new Vector3 (hit.point.x, hit.point.y, -1));

		if (hit.collider) {
			Damageable dmgable = hit.collider.gameObject.GetComponent<Damageable> ();

			if (dmgable != null) {
				dmgable.TakeDamage (damage);
			}
		}
	}

	override public void Reload () {

	}
}
