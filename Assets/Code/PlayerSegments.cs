using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSegments : MonoBehaviour {

    public Transform PlayerHead;
    public Transform PlayerTail;
    public GameObject SegmentPrefab;
    public int numberOfSegments;
    
    private List<HingeJoint> Segments = new List<HingeJoint>();

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
