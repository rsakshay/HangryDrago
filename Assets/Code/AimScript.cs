using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour {
    
    public float aimSpeed = 5;
    public Transform pivot;

    public Vector3 AimDir { get { return -transform.right; } }

    private float currentRotation;

    // Use this for initialization
    void Start () {
        currentRotation = transform.rotation.z;
	}

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, currentRotation);
    }

    // Update is called once per frame
    void Update () {
		CheckAim();
	}
    
    void CheckAim()
    { 
        currentRotation += InputMan.GetLHorizontal() * aimSpeed * Time.deltaTime;
    }
}
