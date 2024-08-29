using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	private Func<Vector3> GetCameraFollowPosition;
	private float _offset = 1f;

	public GameObject zoneOfDeath;

    public void Setup(Func<Vector3> GetCameraFollowPosition){
		this.GetCameraFollowPosition = GetCameraFollowPosition;
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 cameraFollowPosition = GetCameraFollowPosition();
		cameraFollowPosition.z = transform.position.z;
		transform.position = new Vector3(cameraFollowPosition.x, cameraFollowPosition.y + _offset, transform.position.z);
		// zoneOfDeath.transform.position = new Vector3(cameraFollowPosition.x, cameraFollowPosition.y, zoneOfDeath.transform.position.z);
    }
}
