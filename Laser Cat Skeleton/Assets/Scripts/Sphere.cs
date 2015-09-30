using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour {

	public Vector3 direction;
	public float speed;

	// Use this for initialization
	void Start ()
	{
		direction = GameObject.FindGameObjectWithTag ("Player").GetComponent<Camera> ().transform.forward;
//		direction = new Vector3 (direction.x * speed, direction.y * speed, direction.z * speed);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position += direction;
	}
}
