using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class CameraMovement : MonoBehaviour {

    // Camera movement speed
    //public float movementSpeed = 0.25f;
    //public float horizontalRotationSpeed = 5f;
    //public float verticalRotationSpeed = 5f;

    //private float defaultMovementSpeed = 0.25f;
    //private float maxMovementSpeed = 5f;
    //private float yaw = 0f;
    //private float pitch = 0f;

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationX = 0F;
    float rotationY = 0F;
    Quaternion originalRotation;

	// Use this for initialization
	void Start () {
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
        originalRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");
        if (Camera.current != null)
        {
            Camera.current.transform.Translate(new Vector3(xAxisValue * 0.3f, 0.0f, zAxisValue * 0.3f));
        }

        if (axes == RotationAxes.MouseXAndY)
        {
            // Read the mouse input axis
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        }
        else if (axes == RotationAxes.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
        }
        //get a forward orientation vector that is parallel to the ground.
        //Vector3 front = transform.forward;
        //front.y = 0;
        //front.Normalize();

        ////Debug.Log(front);


        //yaw += horizontalRotationSpeed * Input.GetAxis("Mouse X");
        //pitch -= verticalRotationSpeed * Input.GetAxis("Mouse Y");
        //transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        //Vector3 left = Vector3.Cross(front, Vector3.up);

        ////forward/back motion
        //if (Input.GetKey(KeyCode.W))
        //{
        //    movementSpeed += 0.01f;
        //    movementSpeed = Mathf.Min(maxMovementSpeed, movementSpeed);
        //    transform.Translate(movementSpeed * front, Space.World);
        //}
        //else {
        //    movementSpeed = defaultMovementSpeed;
        //    if (Input.GetKey(KeyCode.S)){
        //        transform.Translate(-movementSpeed * front, Space.World);
        //    }
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    movementSpeed = defaultMovementSpeed;
        //    transform.Translate(movementSpeed * left, Space.World);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    movementSpeed = defaultMovementSpeed;
        //    transform.Translate(-movementSpeed * left, Space.World);
        //}
	}

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
