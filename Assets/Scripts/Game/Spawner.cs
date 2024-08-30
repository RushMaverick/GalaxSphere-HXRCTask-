using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	private Transform _centerPoint;
	private Transform _rightPoint;
	public GameObject _colorSwitcher;
	public GameObject _rotatingObstacle;
	public GameObject _movingObstacle;
	public GameObject _blinkObstacle;
	private GameObject[] _objectList;
	private float _spawnTimer = 10f;
	private float _despawnBelowPlayer = 10f;
	private float _spawnDistance = 6f;
	private static int _objectsSpawned = 0;
	public Transform GetChildByName(Transform parent, string childName) { //Searches through the parent by the childName and returns the transform for it if it exists.

		for (int i = 0; i < transform.childCount; i++) {
			Transform child = transform.GetChild(i);
			if (child.name == childName)
				return child;
		}
		Debug.LogError($"Child with name {childName} not found.");
		return null;
	}
	void Start(){
		_objectList = new GameObject[6];
		_centerPoint = GetChildByName(gameObject.transform, "centerPoint");
		_rightPoint = GetChildByName(gameObject.transform, "rightPoint");
		if (_centerPoint == null || _rightPoint == null) {
			Debug.LogError("Center point or right point not found.");
			return;
		}
		Populate(_objectList);
	}

	void Update(){

	}

	void Populate(GameObject[] objectlist){
		for (int i = 0; i <= 5; i++){ 
			if (i % 2 == 0){ //If the index is even, spawn a color switcher
				Vector3 spawnPos = _centerPoint.position + _spawnDistance * Vector3.up;
				GameObject colorSwitch = Instantiate(_colorSwitcher, spawnPos, transform.rotation);
				_objectList[i] = colorSwitch;
			}
			else { //If the index is odd, spawn a random obstacle
				 SpawnRandomObstacle(i);
			}
			_objectsSpawned++;
			this.transform.position += _spawnDistance * Vector3.up; //Move the spawner up
		}
	}

	void SpawnRandomObstacle(int index) {
		Vector3 spawnPos;
		int randIndex = UnityEngine.Random.Range(0, 3);
		switch(randIndex) { // You can easily add more cases here to spawn more types of obstacles, remember to change the Random.Range value to match the number of cases!
			case 0:
				spawnPos = _rightPoint.position + _spawnDistance * Vector3.up; //Spawn the obstacle to the right of the center point
				GameObject rotateObstacle = Instantiate(_rotatingObstacle, spawnPos, transform.rotation); //Instantiate the rotating obstacle
				_objectList[index] = rotateObstacle; 
				break;
			case 1:
				spawnPos = _centerPoint.position + _spawnDistance * Vector3.up; //Spawn the obstacle at the center point
				GameObject moveObstacle = Instantiate(_movingObstacle, spawnPos, transform.rotation); //Instantiate the moving obstacle
				_objectList[index] = _movingObstacle;
				break;
			case 2:
				spawnPos = _centerPoint.position + _spawnDistance * Vector3.up; //Spawn the obstacle at the center point
				GameObject blinkObstacle = Instantiate(_blinkObstacle, spawnPos, transform.rotation); //Instantiate the blinking obstacle
				_objectList[index] = _blinkObstacle;
				break;
		}
	}

	void SpawnObject(){

	}

	void DespawnObject(){

	}

}
