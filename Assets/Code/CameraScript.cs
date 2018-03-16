using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform ObjToFollow;
    public float MoveSpeed = 5;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!Mathf.Approximately(transform.position.x, ObjToFollow.position.x))
        {
            Vector3 finalPos = transform.position;
            finalPos.x = ObjToFollow.position.x;
            transform.position = Vector3.Lerp(transform.position, finalPos, Time.deltaTime * MoveSpeed);
        }
	}
}
