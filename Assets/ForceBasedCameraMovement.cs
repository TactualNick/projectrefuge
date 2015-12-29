using UnityEngine;
using System.Collections;

public class ForceBasedCameraMovement : MonoBehaviour {

    // Camera movement speed
    public float movementSpeed = 0.25f;
    public float horizontalRotationSpeed = 5f;
    public float verticalRotationSpeed = 5f;

    public Rigidbody rb;
    private float yaw = 0f;
    private float pitch = 0f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        yaw += horizontalRotationSpeed * Input.GetAxis("Mouse X");
        pitch -= verticalRotationSpeed * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
	}

    void FixedUpdate()
    {
        Vector3 front = transform.forward;
        front.y = 0;
        front.Normalize();
        Vector3 left = Vector3.Cross(front, Vector3.up);

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(movementSpeed * front);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-movementSpeed * front);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(movementSpeed * left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(-movementSpeed * left);
        }
    }
}
