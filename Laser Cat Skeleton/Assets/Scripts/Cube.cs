using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	public float setrotateSpeed;
	float rotateSpeed;

	Vector3 axisofRotation;

	// Use this for initialization
	void Start ()
	{
		axisofRotation = transform.GetChild (2).transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.RotateAround(axisofRotation, Vector3.up, rotateSpeed);

		GameObject[] spheres = GameObject.FindGameObjectsWithTag ("Sphere");
		for (int i = 0; i < spheres.Length; i++)
		{
			if (spheres[i].GetComponent<SphereCollider>().bounds.Intersects(transform.GetChild(0).GetComponent<BoxCollider>().bounds))
			{
				rotateSpeed = setrotateSpeed;
				Destroy (spheres[i].gameObject);
			}
			else if (spheres[i].GetComponent<SphereCollider>().bounds.Intersects(transform.GetChild(1).GetComponent<BoxCollider>().bounds))
			{
				rotateSpeed = -setrotateSpeed;
				Destroy (spheres[i].gameObject);
			}
		}

		Debug.Log (rotateSpeed);
	}
}
