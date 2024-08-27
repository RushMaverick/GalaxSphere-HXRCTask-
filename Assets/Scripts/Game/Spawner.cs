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
		if (_colorSwitcher == null){
			Debug.LogError("no color swticher avaivalbe");
			return;
		}
		for (int i = 0; i <= 5; i++){ // Instantiates five objects into an array of game objects to pool through.
			if (i % 2 == 0){
				Vector3 spawnPos = _centerPoint.position + _spawnDistance * Vector3.up;
				GameObject colorSwitch = Instantiate(_colorSwitcher, spawnPos, transform.rotation);
				_objectList[i] = colorSwitch;
			}
			else{
				Vector3 spawnPos = _rightPoint.position + _spawnDistance * Vector3.up;
				GameObject rotateObstacle = Instantiate(_rotatingObstacle, spawnPos, transform.rotation);
				_objectList[i] = rotateObstacle;
			}
			_objectsSpawned++;
			this.transform.position += _spawnDistance * Vector3.up;
		}
	}

	void SpawnObject(){

	}

	void DespawnObject(){

	}

}
