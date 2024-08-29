using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingObstacle : MonoBehaviour
{
	private SpriteRenderer _spriteRenderer;
	private float _blinkSpeed = 2f;

	void Start() {
		_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		_spriteRenderer.color = Color.red;
		StartCoroutine(Switch());
	}

	IEnumerator Switch() {
		// Waits for the blink speed then switches the color to one of the four colors
		while (true){
			yield return new WaitForSeconds(_blinkSpeed);
			int randIndex = UnityEngine.Random.Range(0, 4);
			switch(randIndex) {
				case 0:
					_spriteRenderer.color = Color.red;
					gameObject.tag = "Red";
					break;
				case 1:
					_spriteRenderer.color = Color.yellow;
					gameObject.tag = "Yellow";
					break;
				case 2:
					_spriteRenderer.color = Color.blue;
					gameObject.tag = "Blue";
					break;
				case 3:
					_spriteRenderer.color = Color.green;
					gameObject.tag = "Green";
					break;
			}
		}
	}
}
