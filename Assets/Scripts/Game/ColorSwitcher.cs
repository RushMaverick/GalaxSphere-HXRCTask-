using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player" || other.tag == "Green" || other.tag == "Yellow" || other.tag == "Red" || other.tag == "Blue"){
			Destroy(gameObject); //Change this to object pooling if you have time
		}
	}
}
