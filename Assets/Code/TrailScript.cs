using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour {

    [Range(5, 100)]
    public int NumPoints = 20;

    PlayerFlingScript player;
    LineRenderer lineRend;
    private const float gravity = 9.814f;

	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<PlayerFlingScript>();
        lineRend = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!player.IsJumping && player.IsAiming)
        {
            ShowTrail();
        }
        else
        {
            DeleteTrail();
        }
	}

    void DeleteTrail()
    {
        lineRend.positionCount = 0;
    }

    void ShowTrail()
    {
        lineRend.positionCount = 0;
        lineRend.useWorldSpace = false;

        lineRend.positionCount = NumPoints;

        int flipped = -1;

        //float zAngle = player.transform.localEulerAngles.z;
        //zAngle = (zAngle < 0) ? zAngle + 360 : zAngle;

        //if (Mathf.Abs(180 - zAngle) < 5)
        //{
        //    flipped = 1;
        //}

        Vector2 uVel = player.JumpVel;
        //Vector3 startPos = player.transform.position;

        float distance = Mathf.Abs(uVel.x * uVel.y / gravity);
        float frac = distance / NumPoints;

        for (int i = 0; i < NumPoints; i++)
        {
            Vector3 point = Vector3.zero;
            point.x = i * frac;

            float time = point.x / uVel.x;

            point.y = (uVel.y * time) + (flipped * (gravity / 2) * Mathf.Pow(time, 2));
            
            lineRend.SetPosition(i, point);
        }
    }
}
