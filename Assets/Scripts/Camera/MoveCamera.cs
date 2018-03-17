using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public Transform player;
    public float movementSpeed;

    Vector3 velocity;

    void Start()
    {
        transform.position = new Vector3(player.position.x, DataTypes.Constants.FURTHEST_CAMERA_DOWN + 0.1f, transform.position.z);
    }

	void Update()
    {
        Move();
    }

    private void Move()
    {
        bool moveVert = false;
        bool moveHorizontal = false;

        if (player.position.x > DataTypes.Constants.FURTHEST_CAMERA_LEFT &&
            player.position.x < DataTypes.Constants.FURTHEST_CAMERA_RIGHT)
        {
            moveHorizontal = true;
        }

        if (player.position.y < DataTypes.Constants.FURTHEST_CAMERA_UP &&
            player.position.y > DataTypes.Constants.FURTHEST_CAMERA_DOWN)
        {
            moveVert = true;
        }

        Vector3 nextPosition = new Vector3(moveHorizontal ? player.position.x : transform.position.x, moveVert ? player.position.y : transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, nextPosition, Time.time * movementSpeed);
    }
}
