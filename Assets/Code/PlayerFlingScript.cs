using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerFlingScript : MonoBehaviour {

    public float MINvelocity = 3;
    public float MAXvelocityPower = 7;
    public float TweenTime = 1;
    public AimScript aim;

    public AudioClip flingAudio;
    public AudioClip landAudio;
    public AudioClip eatAudio;

    public Text gameOverText;
    
    private Rigidbody rgb;
    private AudioSource myAudioSource;
    private bool flingHeld = false;
    private const string flingKey = "X";
    private const string endKey = "Y";
    private float currentImpuleVelocity = 0;
    private float flingStartTime;

    // Use this for initialization
    void Awake ()
    {
        rgb = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();
        gameOverText.gameObject.SetActive(false);
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
            currentImpuleVelocity = Mathf.Lerp(MINvelocity, MAXvelocityPower, percentComplete);

            if (InputMan.GetButtonUp(flingKey))
            {
                Fling();
                flingHeld = false;
            }
        }

        if(InputMan.GetButtonDown(endKey))
        {
            gameOverText.gameObject.SetActive(true);
            InputMan.DisableControls();
        }
    }

    void Fling()
    {
        //rgb.AddForce(aim.AimDir * currentImpulsePower, ForceMode.Impulse);
        myAudioSource.PlayOneShot(flingAudio);
        rgb.velocity = aim.AimDir * currentImpuleVelocity;
    }

    private void OnCollisionStay(Collision collision)
    {
        if ((int)rgb.velocity.y > 0)
            return;

        //if (collision.gameObject.tag.ToLower() != "blocker")
        //{
        //    myAudioSource.PlayOneShot(landAudio);
        //}

        rgb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag.ToLower() != "blocker")
        //{
        //    myAudioSource.PlayOneShot(landAudio);
        //}

        rgb.angularVelocity = Vector3.zero;
    }

    public void PlayEatingSound()
    {
        myAudioSource.PlayOneShot(eatAudio);
    }
}
