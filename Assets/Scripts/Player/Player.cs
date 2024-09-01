using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
	public GameManager _gmanager;
	private bool _playerPassed = false; //This is used to prevent the player from spawning multiple stars from one trigger collider.
	public GameObject _star;
	public ScoreTracking _uid;
	private Rigidbody2D _rb2d;
	private float _winTime = 0.5f;
	private float _destructionTime = 1f; // Used only for resetting the game when the player dies.
	private int _lastColor;
	private SpriteRenderer _spriteRenderer;
	private Transform _deathPs;
	private Transform _starPs;
	private float _thrust = 5f;
	private float _spawnDistance = 4f; //Distance from the StarSpawn object to spawn the star.
	private int _score = 0;


	public Transform GetChildByName(Transform parent, string childName) { //Searches through the parent by the childName and returns the transform for it if it exists, otherwise it throws an error.

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
		_deathPs = this.GetChildByName(gameObject.transform, "PlayerDeath");
		_starPs = this.GetChildByName(gameObject.transform, "StarCollected");
		_lastColor = 0;
    }

    void Update() {
        if (Input.GetKeyDown("space")){
			_rb2d.velocity = Vector2.up * _thrust;
		}
		if (_score == 5) {
			StartCoroutine(WinScreen());
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		string tagName = other.tag;
		Debug.Log($"Player collided with {tagName}");
		switch (tagName){
			case "Finish":
				PlayerDeath();
				break;
			case "Star":
				CollectStar();
				break;
			case "Yellow":
			case "Red":
			case "Blue":
			case "Green":
				if (this.tag != tagName)
					PlayerDeath();
				break;
			case "StarSpawn":
				if (!_playerPassed) 
					SpawnStar(other.transform);
				break;
			case "ColorSwitcher":
				SwitchColor();
				break;
		}
	}

	void SpawnStar(Transform other) { //Spawns a star at the position of the StarSpawn object plus the _spawnDistance upwards.
		Instantiate(_star, other.position + Vector3.up * _spawnDistance, transform.rotation);
		_playerPassed = true;
	}

	public void CollectStar() {
		FindObjectOfType<AudioManager>().PlayAudio("CollectStar");
		Debug.Log("Star collected!");
		_playerPassed = false;
		_score++;
		_uid.UpdateScore(_score);
		_starPs.GetComponent<ParticleSystem>().Play();
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
		FindObjectOfType<AudioManager>().PlayAudio("SwitchColor"); //Plays the audio for the color switch.

		// Switch case based on color, changes the Player tag as well for hit detection.
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
		}
		Debug.Log($"Color switched to " + _spriteRenderer.tag);
	}

	private void PlayerDeath() {
		FindObjectOfType<AudioManager>().PlayAudio("PlayerDeath");
		_rb2d.simulated = false;
		_spriteRenderer.enabled = false;
		_deathPs.GetComponent<ParticleSystem>().Play();
		StartCoroutine(ResetGame()); //Starts a timer for the destruction of the Player so the animation can finish. Could also be triggered through an animation event.
	}

	private IEnumerator WinScreen() {
		yield return new WaitForSeconds(_winTime);
		_gmanager.LoadScene("WinScene");
	}

	private IEnumerator ResetGame() {
		yield return new WaitForSeconds(_destructionTime);
		_gmanager.LoadScene("GameScene");
	}
}
