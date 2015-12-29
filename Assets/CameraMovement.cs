using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    // Camera movement speed
    public float speed = 0.5f;
    public float horzCamSpeed = 2f;
    public float vertCamSpeed = 2f;

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


        yaw += horzCamSpeed * Input.GetAxis("Mouse X");
        pitch -= vertCamSpeed * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        Vector3 left = Vector3.Cross(front, Vector3.up);

        //forward/back motion
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("hello!");
            transform.Translate(speed * front);
        }
        else if (Input.GetKey(KeyCode.S))
        {

            Debug.Log("hello!");
            transform.Translate(-speed * front);
        }

        if (Input.GetKey(KeyCode.A))
        {

            Debug.Log("hello!");
            transform.Translate(speed * left);
        }
        else if (Input.GetKey(KeyCode.D))
        {

            Debug.Log("hello!");
            transform.Translate(-speed * left);
        }
	}
}
