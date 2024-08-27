using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	private Transform _spawnPoint;
	public GameObject _colorSwitcher;
	private GameObject[] _objectList;
	private float _spawnTimer = 10f;
	private float _despawnBelowPlayer = 10f;
	private float _spawnDistance = 5f;
	private static int _objectsSpawned = 0;
	void Start(){
		_objectList = new GameObject[5];
		Populate(_objectList);
	}

	void Update(){

	}

	void Populate(GameObject[] objectlist){
		if (_colorSwitcher == null){
			Debug.LogError("no color swticher avaivalbe");
			return;
		}
		for (int i = 0; i <= 4; i++){ // Instantiates five objects into an array of game objects to pool through.
			GameObject newGameObject = Instantiate(_colorSwitcher, transform.position + _spawnDistance * Vector3.up, transform.rotation);
			_objectList[i] = newGameObject;
			_objectsSpawned++;
			_despawnBelowPlayer += 5f;
		}
	}

	void SpawnObject(){

	}

	void DespawnObject(){

	}

}
