using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFill : MonoBehaviour {
	[SerializeField]
	private Slider slider;
	public Gradient gradient;
	public Image fill;

	public void Start () {
		transform.localPosition = new Vector3(0f, 0.8f, 0f);
	}

	public void Update () {
		transform.rotation = Quaternion.identity;
	}

	public void SetMaxValue (int health) {
		slider.maxValue = health;

		UpdateGradient ();
	}

	public void SetValue (int health) {
		slider.value = health;

		UpdateGradient ();
	}

	private void UpdateGradient () {
		fill.color = gradient.Evaluate (slider.normalizedValue);
	}
}
