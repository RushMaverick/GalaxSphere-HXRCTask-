using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody2D _rb2d;
	private float thrust = 3f;

	void Awake()
    {
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("space")){
			_rb2d.AddForce(transform.up * thrust, ForceMode2D.Impulse);
			Debug.Log("JUMP");
		}
    }
}
