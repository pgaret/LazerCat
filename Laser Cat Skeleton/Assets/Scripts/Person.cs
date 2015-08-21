using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {

	public Transform sphere;
	public Vector3 lookingAt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		lookingAt = transform.GetChild(0).forward;

		if (Input.GetKeyUp (KeyCode.Space))
		{	
			Instantiate(sphere);
		}
	}
}
