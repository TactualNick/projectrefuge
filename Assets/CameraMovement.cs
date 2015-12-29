using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    // Camera movement speed
    public float movementSpeed = 0.5f;
    public float horizontalRotationSpeed = 2f;
    public float verticalRotationSpeed = 2f;

    private float yaw = 0f;
    private float pitch = 0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
        //get a forward orientation vector that is parallel to the ground.
        Vector3 front = transform.forward;
        front.y = 0;
        front.Normalize();

        Debug.Log(front);


        yaw += horizontalRotationSpeed * Input.GetAxis("Mouse X");
        pitch -= verticalRotationSpeed * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        Vector3 left = Vector3.Cross(front, Vector3.up);

        //forward/back motion
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(movementSpeed * front, Space.World);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-movementSpeed * front, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(movementSpeed * left, Space.World);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-movementSpeed * left, Space.World);
        }
	}
}
