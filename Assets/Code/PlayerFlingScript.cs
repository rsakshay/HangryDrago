using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerFlingScript : MonoBehaviour {

    public float MINVelocity = 5;
    public float MAXVelocity = 15;
    public float TweenTime = 1;
    public float CD = 1;
    public AimScript aim;

    private Rigidbody rgb;
    private bool flingHeld = false;
    private const string flingKey = "X";
    private float currentImpulsePower = 0;
    private float flingStartTime;
    private bool isJumping = false;
    private float jumpStartTime;

    public Vector3 JumpVel { get { return aim.AimDir * currentImpulsePower; } }
    public bool IsJumping { get { return isJumping; } }
    public bool IsAiming { get { return flingHeld; } }

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

        if (flingHeld && JumpCheck())
        {
            float percentComplete = (Time.time - flingStartTime) / TweenTime;
            currentImpulsePower = Mathf.Lerp(MINVelocity, MAXVelocity, percentComplete);

            if (InputMan.GetButtonUp(flingKey))
            {
                Fling();
                flingHeld = false;
            }
        }
    }

    bool JumpCheck()
    {
        if (isJumping || Time.time - jumpStartTime < CD)
            return false;

        return true;
    }

    void Fling()
    {
        rgb.velocity = aim.AimDir * currentImpulsePower;
        //rgb.AddForce(aim.AimDir * currentImpulsePower, ForceMode.Impulse);
        isJumping = true;
        jumpStartTime = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.tag.ToLower().Contains("Blocker"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if ((int)rgb.velocity.y > 0)
            return;

        if (!collision.gameObject.tag.ToLower().Contains("Blocker"))
        {
            isJumping = false;
        }
        rgb.angularVelocity = Vector3.zero;
    }
}
