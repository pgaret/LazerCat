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

		if (onCube == true && Input.GetKeyDown(KeyCode.Return))
		{
			attainedDirection = true;
			transform.parent = null;
			onCube = false;
			direction = Camera.main.transform.forward;
		}
		Debug.Log (onCube);
		if (attainedDirection == true && onCube == false) transform.position += direction * GetComponent<PlayerMovement>().playerSpeed * Time.deltaTime;
	}
}
