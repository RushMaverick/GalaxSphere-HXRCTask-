using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private string _score;
	void Start(){
		Screen.SetResolution(720, 1280, FullScreenMode.Windowed);
	}

	public void LoadScene(string name){
		SceneManager.LoadScene(name);
	}

}
