using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
	private Vector3 _targetPos;
	public GameObject _leftPoint;
	public GameObject _rightPoint;
	private SpriteRenderer _spriteRenderer;
	private Vector3 _startPos;
	private bool _isMovingRight = true;
	private float _moveSpeed = 11.00f;

	void Start() {
		//Store initial positions
		_startPos = transform.position;
		_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		RandomizeColor();
		_targetPos = _rightPoint.transform.position;
	}
	void Update(){
		MoveHorizontal();
	}

	void RandomizeColor() {
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

	public void MoveHorizontal() {
		// Check if we're moving right
		if (_isMovingRight){
			// Move the obstacle horizontally towards the target position
			transform.position = Vector3.MoveTowards(transform.position, _targetPos, _moveSpeed * Time.deltaTime);
			
			// If we've reached the target x-position, stop moving right and set new target
			if (transform.position.x >= _targetPos.x){
				_isMovingRight = false;
				_targetPos = _leftPoint.transform.position;
			}
		}

		// If not moving right, start moving left
		else {
			transform.position = Vector3.MoveTowards(transform.position, _targetPos, _moveSpeed * Time.deltaTime);

			 // If we've reached the target x-position, start moving right and set new target
			if (transform.position.x <= _targetPos.x){
				_isMovingRight = true;
				_targetPos = _rightPoint.transform.position;
			}
		}
	}
}

