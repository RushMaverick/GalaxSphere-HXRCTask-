using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody2D _rb2d;
	private SpriteRenderer _spriteRenderer;
	private Transform _ps; 
	private float thrust = 5f;

	//Searches through the parent by the childName and returns the transform for it if it exists.
	public Transform GetChildByName(Transform parent, string childName) {

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
		_ps = this.GetChildByName(gameObject.transform, "PlayerDeath");
    }
	void Start() {
	}

    void Update() {
        if (Input.GetKeyDown("space")){
			_rb2d.velocity = Vector2.up * thrust;
			Debug.Log("JUMP");
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
			PlayerDeath();
	}

	void PlayerDeath() {
		_rb2d.simulated = false;
		_spriteRenderer.enabled = false;
		_ps.GetComponent<ParticleSystem>().Play();
	}
}
