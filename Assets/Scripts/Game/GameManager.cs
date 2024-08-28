using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
	public FollowCamera _camFollow;
	private string _score;
	public Transform _playerLoc;
	void Start(){
		_camFollow.Setup(() => _playerLoc.position);
		
		// _uid.rootVisualElement.Q<Label>("Score").text = "0";
    }

	public void ResetGame(){
		Debug.Log("Reset go brrrrr.");
	}

}
