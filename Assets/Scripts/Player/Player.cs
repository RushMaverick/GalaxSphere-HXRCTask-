using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody2D _rb2d;
	private int _lastColor;
	private SpriteRenderer _spriteRenderer;
	private Transform _ps; 
	private float thrust = 5f;


	public Transform GetChildByName(Transform parent, string childName) { //Searches through the parent by the childName and returns the transform for it if it exists.

		for (int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild(i);
			if (child.name == childName)
				return child;
		}
		Debug.LogError($"Child with name {childName} not found.");
		return null;
	}

	void Awake() {
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		_spriteRenderer.color = Color.red;
		_ps = this.GetChildByName(gameObject.transform, "PlayerDeath");
		_lastColor = 0;
    }
	void Start() {
	}

    void Update() {
        if (Input.GetKeyDown("space")){
			_rb2d.velocity = Vector2.up * thrust;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Finish")
			PlayerDeath();
		if (other.tag == "Green" || other.tag == "Yellow" || other.tag == "Red" || other.tag == "Blue"){
			if (this.tag == other.tag)
				PlayerDeath();
		}
		if (other.tag == "ColorSwitcher")
			SwitchColor();
	}

	private void SwitchColor(){
		int randIndex = 0;
		Color[] colors = new Color[]
		{
			Color.red,
			Color.blue,
			Color.green,
			Color.yellow
		};
		
		while (randIndex == _lastColor)
			randIndex = UnityEngine.Random.Range(0, colors.Length); //This randomizes the color by using Random.Range to randomize a number to pick from the Color array.
		_lastColor = randIndex;
		_spriteRenderer.color = colors[randIndex];
		// Switch case based on color
		switch (randIndex)
		{
			case 0:
				_spriteRenderer.tag = "Red";
				break;
			case 1:
				_spriteRenderer.tag = "Blue";
				break;
			case 2:
				_spriteRenderer.tag = "Green";
				break;
			case 3:
				_spriteRenderer.tag = "Yellow";
				break;
			default:
				Debug.LogError("Unknown color");
				break;
		}
	}

	private void PlayerDeath() {
		_rb2d.simulated = false;
		_spriteRenderer.enabled = false;
		_ps.GetComponent<ParticleSystem>().Play();
	}
}
