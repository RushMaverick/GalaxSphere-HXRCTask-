using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	private Transform _target;
	private float _lastPlayerY;
	private float _offset = 0.5f;

	void Start() {
		_target = GameObject.FindWithTag("Player").transform;
		if (_target == null)
			Debug.LogError("Player not found");
		_lastPlayerY = _target.position.y;
	}

	void LateUpdate() {
		if (_target.position.y > _lastPlayerY) { // Camera follows the player only when the player is above the last position
			_lastPlayerY = _target.position.y;
			Vector3 cameraPos = new Vector3(transform.position.x, _lastPlayerY + _offset, transform.position.z); // Camera follows the player with specified offset position
			Vector3 smoothPos = Vector3.Lerp(transform.position, cameraPos, 0.1f); // Smooth camera movement
			transform.position = smoothPos;
		}
	}
}
