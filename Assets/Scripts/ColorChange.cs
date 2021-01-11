using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour, Damageable
{
	int i = 0;
	Color[] colors = new Color[] { Color.red, Color.blue, Color.green };
	Material mat;

	public void Start() {
		mat = GetComponent<MeshRenderer>().material;
	}

	public void TakeDamage(float dmg) {
		if (++i >= colors.Length) {
			i = 0;
		}

        mat.color = colors[i];
	}
}
