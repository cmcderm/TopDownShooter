using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFill : MonoBehaviour
{
	[SerializeField]
	private Slider slider;
	public Gradient gradient;
	public Image fill;

	public void SetMaxHealth(int health) {
		slider.maxValue = health;

		UpdateGradient();
	}

	public void SetHealth(int health) {
		slider.value = health;

		UpdateGradient();
	}

	private void UpdateGradient() {
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
