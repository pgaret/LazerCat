using UnityEngine;
using System.Collections;


/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation


/// To make an FPS style character:
/// - Create a capsule.
/// - Add a rigid body to the capsule
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSWalker script to the capsule


/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {
	
	
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;

    public Vector3 origRot;

	float rotationX = 0F;
	float rotationY = 0F;
	Quaternion originalRotation;
	void Update ()
	{
        Debug.Log(transform.rotation);
        
        Debug.Log(transform.rotation);
        //       Debug.Log(transform.rotation.eulerAngles);
        
        if (axes == RotationAxes.MouseXAndY)
		{
			// Read the mouse input axis
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);
			transform.localRotation = originalRotation * xQuaternion * yQuaternion;
		}
		else if (axes == RotationAxes.MouseX)
		{
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
			Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			transform.localRotation = originalRotation * xQuaternion;
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis (-rotationY, Vector3.right);
			transform.localRotation = originalRotation * yQuaternion;
		}
        if (GetComponent<Person>().onCube == true)
        {
            Transform cube = GetComponent<Person>().cube;
            Vector3 change = cube.transform.rotation.eulerAngles - origRot;
            Debug.Log("CHANGE: " + change);
            Debug.Log(change.y);
            //           transform.Rotate(0, cube.GetComponent<Cube>().rotateSpeed * Time.deltaTime, 0);
            change = change + transform.rotation.eulerAngles * 360;
            Debug.Log("BEFORE THE CHANGE SHOULD OCCUR: " + transform.rotation.eulerAngles);
            transform.rotation = Quaternion.Euler(change);
            Debug.Log("AFTER THE CHANGE SHOULD OCCUR: " + transform.rotation.eulerAngles);
            origRot = cube.transform.rotation.eulerAngles;

            if (GetComponent<Person>().cubeFace == 1)
            {
                minimumX = cube.localEulerAngles.y % 360;
                maximumX = (cube.localEulerAngles.y + 180F) % 360;
                if (maximumX < minimumX)
                {
                    maximumX += 360;
                }
                //              Debug.Log(minimumX + "   " + maximumX);
            }

            else if (GetComponent<Person>().cubeFace == 0)
            {
                minimumX = cube.localEulerAngles.y + -180F;
                maximumX = cube.localEulerAngles.y;
            }
            //          Debug.Log(rotationX + "   " + rotationY);
            rotationX = Clamp();
        }
        Debug.Log("FINAL CONDITION IS: " + transform.rotation.eulerAngles);
	}

    float Clamp()
    {
        if (rotationX < 10 && (minimumX > 350 || maximumX > 350))
        {
  //          Debug.Log("Minx: " + minimumX + " MaxX" + maximumX + " rotX: " + rotationX);
            return(Mathf.Clamp(rotationX + 360, minimumX, maximumX));
        }
        else if (rotationX > 350 && (minimumX < 10 || maximumX < 10))
        {
 //           Debug.Log("Minx: " + minimumX + " MaxX" + maximumX + " rotX: " + rotationX);
            return (Mathf.Clamp(rotationX - 360, minimumX, maximumX));
        }
        else return (rotationX);
    }

	void Start ()
	{
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
		originalRotation = transform.localRotation;
	}
}