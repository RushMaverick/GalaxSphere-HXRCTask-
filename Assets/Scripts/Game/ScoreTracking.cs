using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreTracking : MonoBehaviour
{
	private UIDocument _uid;
	private Label _score; //Text that contains the score in the UI element
	void Start()
	{
		_uid = gameObject.GetComponent<UIDocument>();
		_score = _uid.rootVisualElement.Q<Label>("Score");
		_score.text = "0";
	}

	public void UpdateScore(int score){
		_score.text = score.ToString();
	}
}
