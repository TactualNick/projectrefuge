﻿using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

    // Camera movement speed
    public float movementSpeed = 0.25f;
    public float horizontalRotationSpeed = 5f;
    public float verticalRotationSpeed = 5f;

    private float defaultMovementSpeed = 0.25f;
    private float maxMovementSpeed = 5f;
    private float yaw = 0f;
    private float pitch = 0f;

    private bool camera_frozen = false;

    // Use this for initialization
    private void Start()
    {
    }

    private void freezeCamera()
    {
        camera_frozen = true;
    }

    private void unfreezeCamera()
    {
        camera_frozen = false;
    }

    // Update is called once per frame
    private void Update()
    {

        //get a forward orientation vector that is parallel to the ground.
        Vector3 front = transform.forward;
        front.y = 0;
        front.Normalize();

        //Debug.Log(front);


        yaw += horizontalRotationSpeed*Input.GetAxis("Mouse X");
        pitch -= verticalRotationSpeed*Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        Vector3 left = Vector3.Cross(front, Vector3.up);

        //forward/back motion
        if (Input.GetKey(KeyCode.W))
        {
            movementSpeed += 0.01f;
            movementSpeed = Mathf.Min(maxMovementSpeed, movementSpeed);
            transform.Translate(movementSpeed*front, Space.World);
        }
        else
        {
            movementSpeed = defaultMovementSpeed;
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-movementSpeed*front, Space.World);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (camera_frozen) unfreezeCamera();
                else freezeCamera();
            }

            if (Input.GetKey(KeyCode.A))
            {
                movementSpeed = defaultMovementSpeed;
                transform.Translate(movementSpeed*left, Space.World);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movementSpeed = defaultMovementSpeed;
                transform.Translate(-movementSpeed*left, Space.World);
            }

            if (!camera_frozen)
            {
                //get a forward ori	entation vector that is parallel to the ground.
                front = transform.forward;
                front.y = 0;
                front.Normalize();

                //Debug.Log(front);


                yaw += horizontalRotationSpeed*Input.GetAxis("Mouse X");
                pitch -= verticalRotationSpeed*Input.GetAxis("Mouse Y");
                transform.eulerAngles = new Vector3(pitch, yaw, 0f);

                left = Vector3.Cross(front, Vector3.up);

                //forward/back motion


                if (Input.GetKey(KeyCode.W))
                {
                    movementSpeed += 0.01f;
                    movementSpeed = Mathf.Min(maxMovementSpeed, movementSpeed);
                    transform.Translate(movementSpeed*front, Space.World);
                }
                else
                {
                    movementSpeed = defaultMovementSpeed;
                    if (Input.GetKey(KeyCode.S))
                    {
                        transform.Translate(-movementSpeed*front, Space.World);
                    }
                }

                if (Input.GetKey(KeyCode.A))
                {
                    movementSpeed = defaultMovementSpeed;
                    transform.Translate(movementSpeed*left, Space.World);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    movementSpeed = defaultMovementSpeed;
                    transform.Translate(-movementSpeed*left, Space.World);
                }
            }
        }
    }
}
