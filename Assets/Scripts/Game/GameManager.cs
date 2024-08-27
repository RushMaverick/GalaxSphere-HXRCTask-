using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public FollowCamera _camFollow;
	public Transform _playerLoc;
    void Start()
    {
		Debug.Log(_playerLoc.position);
		_camFollow.Setup(() => _playerLoc.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
