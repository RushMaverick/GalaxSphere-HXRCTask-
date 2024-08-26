using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player"){
			Destroy(gameObject); //Change this to object pooling if you have time
		}
	}
}
