using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBG : MonoBehaviour
{
	private RawImage _rect;
	private float _x = 0.02f;
	private float _y = 0.02f; 
	void Update() {
		_rect = GetComponent<RawImage>();
		_rect.uvRect = new Rect(_rect.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _rect.uvRect.size);
	}
}
