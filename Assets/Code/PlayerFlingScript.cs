using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerFlingScript : MonoBehaviour {

    public float aimSpeed = 5;
    public float MINImpulsePower = 3;
    public float MAXImpulsePower = 7;
    public float TweenTime = 1;

    private Rigidbody rgb;
    private bool flingHeld = false;
    private const string flingKey = "X";
    private float currentImpulsePower = 0;
    private float flingStartTime;

    // Use this for initialization
    void Awake ()
    {
        rgb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (InputMan.GetButtonDown(flingKey) && !flingHeld)
        {
            flingHeld = true;
            flingStartTime = Time.time;
        }

        if (flingHeld)
        {
            float percentComplete = (Time.time - flingStartTime) / TweenTime;
            currentImpulsePower = Mathf.Lerp(MINImpulsePower, MAXImpulsePower, percentComplete);

            if (InputMan.GetButtonUp(flingKey))
            {
                Fling();
                flingHeld = false;
            }
        }

        CheckAim();
    }

    void CheckAim()
    {
        float rotation = InputMan.GetLHorizontal();

        transform.Rotate(new Vector3(0, 0, -rotation));
    }

    void Fling()
    {
        rgb.AddForce(transform.right * currentImpulsePower, ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision collision)
    {
        rgb.angularVelocity = Vector3.zero;
        //rgb.velocity = Vector3.zero;
    }
}
