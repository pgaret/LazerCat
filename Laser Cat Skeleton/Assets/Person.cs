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
    public int cubeFace = -1;

    //Variables for launch camera movement
    public float distanceConst;
    bool haveMoved = true;

    //Variables for shitty testing
    float previousIncrease;

    // Use this for initialization
    void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
//        Transform curCube = GameObject.FindGameObjectWithTag("Cube").transform;
//        Debug.Log(Vector3.Distance(curCube.GetChild(0).position, transform.position) + "      " + Vector3.Distance(curCube.GetChild(1).position, transform.position));

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
                Debug.Log("We're scooting backwards");
            }

        }
        if (onCube == true)
        {
            if (GetComponent<Person>().cubeFace == 0)
            {
                transform.rotation = Quaternion.Euler(cube.rotation.x, cube.rotation.y + 90, cube.rotation.z);
            }

            else if (GetComponent<Person>().cubeFace == 1)
            {
                transform.rotation = Quaternion.Euler(cube.rotation.x, cube.rotation.y - 90, cube.rotation.z);
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
