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

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Space))
		{	
			Instantiate(sphere, transform.position, Quaternion.identity);
		}

		if (onCube == false) GetComponent<SphereCollider>().radius = .1f;

		if (onCube == true && Input.GetKeyDown(KeyCode.LeftShift))
		{
			attainedDirection = true;
			transform.parent = null;
			onCube = false;
			direction = GetComponent<Camera>().transform.forward;
		}
		if (attainedDirection == true && onCube == false) transform.position += direction * GetComponent<PlayerMovement>().playerSpeed * Time.deltaTime;
	}
}
