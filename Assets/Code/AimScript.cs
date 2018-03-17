using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour {
    
    public float aimSpeed = 5;
    public Transform pivot;

    public Vector3 AimDir { get { return -transform.right; } }
	
	// Update is called once per frame
	void Update ()
    {
		CheckAim();
	}
    
    void CheckAim()
    {
        float rotation = InputMan.GetLHorizontal();

        transform.Rotate(Vector3.forward, rotation * aimSpeed);
    }
}
