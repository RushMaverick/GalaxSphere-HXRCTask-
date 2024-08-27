using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public FollowCamera _camFollow;
	public Transform _playerLoc;
    void Start()
    {
		_camFollow.Setup(() => _playerLoc.position);
    }

	public void ResetGame(){
		Debug.Log("Reset go brrrrr.");
	}

    // Update is called once per frame
    void Update()
    {

    }
}
