using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float playerSpeed;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.W))
		{
			transform.position += GetComponent<Camera>().transform.forward * playerSpeed * Time.deltaTime;
		}
	}
}
