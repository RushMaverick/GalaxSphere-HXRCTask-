using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
	private float degreesPerSecond = 15f;
	void Start(){
	}
	void Update(){
		transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
	}
}