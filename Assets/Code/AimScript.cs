using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour {
    
    public float aimSpeed = 5;
    public Transform pivot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckAim();
	}
    
    void CheckAim()
    {
        float rotation = -InputMan.GetLHorizontal();

        transform.RotateAround(pivot.position, Vector3.forward, rotation * aimSpeed);
    }
}
