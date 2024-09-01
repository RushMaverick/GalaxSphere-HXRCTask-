using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
	void Start() {
		// Play the win sound
		FindObjectOfType<AudioManager>().PlayAudio("Win");

		StartCoroutine(ResetGame());
	}

	IEnumerator ResetGame() {
		yield return new WaitForSeconds(6);
		FindObjectOfType<GameManager>().LoadScene("GameScene");
	}
}
