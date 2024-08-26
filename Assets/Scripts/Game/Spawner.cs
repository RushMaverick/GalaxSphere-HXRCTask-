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
	private static int _objectsSpawned = 0;
	void Start(){
		Instantiate(_colorSwitcher, transform.position, transform.rotation);
	}

	void Update(){

	}

	void Populate(GameObject[] objectlist){
	}

	void SpawnObject(){

	}

	void DespawnObject(){

	}

}
