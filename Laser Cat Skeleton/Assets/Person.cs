using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {

	//Shoot spheres to make objects rotate
	public Transform sphere;

	//Are we on a rotating object
	public bool onCube = false;

	//Are we dead
	public bool onDeath = false;

	//Do we have a direction?  Go in that direction
	Vector3 direction;
	bool attainedDirection = false;

	//Current cube (if any)
	public Transform cube;

    //Variables for launch camera movement
    public float distanceConst;
    bool haveMoved = true;

    // Use this for initialization
    void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
        Debug.Log(transform.lossyScale + "     " + transform.localScale);

		if (Input.GetKeyUp (KeyCode.Space))
		{	
			Instantiate(sphere, transform.position, Quaternion.identity);
		}

        if (onCube == false)
        {

            if (haveMoved == false)
            {
                transform.GetChild(0).GetComponent<Camera>().transform.position = transform.position - transform.GetChild(0).GetComponent<Camera>().transform.forward * distanceConst;
                haveMoved = true;
            }

        }

		if (onCube == true && Input.GetKeyDown(KeyCode.LeftShift))
		{
			attainedDirection = true;
			transform.parent = null;
			onCube = false;
			direction = transform.GetChild(0).GetComponent<Camera>().transform.forward;
            haveMoved = false;
        }
		if (attainedDirection == true && onCube == false) transform.position += direction * GetComponent<PlayerMovement>().playerSpeed * Time.deltaTime;
	}
}
