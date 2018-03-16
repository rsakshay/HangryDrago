using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour {
    
    public float aimSpeed = 5;
    public Transform pivot;

    private HingeJoint hJoint;

    public Vector3 AimDir { get { return -transform.right; } }

	// Use this for initialization
	void Start () {
        hJoint = GetComponent<HingeJoint>();
	}
	
	// Update is called once per frame
	void Update () {
		CheckAim();
	}
    
    void CheckAim()
    {
        if (hJoint.angle < hJoint.limits.min || hJoint.angle > hJoint.limits.max)
        {
            return;
        }

        float rotation = InputMan.GetLHorizontal();

        transform.Rotate(Vector3.forward, rotation * aimSpeed);
    }
}
