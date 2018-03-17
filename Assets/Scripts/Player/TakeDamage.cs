using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    public float forceAmount;
    public Color damageColor;
    public Rigidbody myRigidbody;
    private Color originalColor;

    public float iFrames;
    private float currentiFrameCounter;
    private bool isInvuln;

    private List<MeshRenderer> myMeshRenderer = new List<MeshRenderer>();
    private Gradient g = new Gradient();

    private void Start()
    {
        myMeshRenderer.AddRange(GetComponentsInChildren<MeshRenderer>());

        originalColor = myMeshRenderer[0].material.color;
        isInvuln = false;
    }

    private void Update()
    {
        if (currentiFrameCounter < iFrames)
        {
            currentiFrameCounter += Time.deltaTime;
            var color = g.Evaluate(currentiFrameCounter);
            for (int i = 0; i < myMeshRenderer.Count; i++)
            {
                myMeshRenderer[i].material.color = color;
            }
        }
        else
        {
            isInvuln = false;
        }
    }

    public void PlayerTakeDamage(Transform other)
    {
        if (!isInvuln)
        {
            var pushDirection = new Vector3(0.0f, 0.0f, 0.0f);

            // Push up and to the left
            if (other.position.x > transform.position.x)
            {
                pushDirection = new Vector3(-1.0f, 1.0f, 0.0f);
            }
            // Push up and to the right
            else
            {
                pushDirection = new Vector3(1.0f, 1.0f, 0.0f);
            }

            // Zero out the force before adding a new impulse
            myRigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            myRigidbody.AddForce(pushDirection * forceAmount, ForceMode.Impulse);

            // Flash damage color
            GradientColorKey[] gck = new GradientColorKey[2];
            GradientAlphaKey[] gak = new GradientAlphaKey[2];
            gck[0].color = damageColor;
            gck[0].time = 0.0F;
            gck[1].color = originalColor;
            gck[1].time = iFrames + 0.5f;
            gak[0].alpha = 1.0F;
            gak[0].time = 0.0F;
            gak[1].alpha = 1.0F;
            gak[1].time = iFrames;
            g.SetKeys(gck, gak);

            currentiFrameCounter = 0.0f; ;
            isInvuln = true;
        }   
    }
}
