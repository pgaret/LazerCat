using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	public float rotateSpeed = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(Vector3.right*Time.deltaTime*rotateSpeed);

		GameObject[] spheres = GameObject.FindGameObjectsWithTag ("Sphere");
		for (int i = 0; i < spheres.Length; i++)
		{
			if (spheres[i].GetComponent<SphereCollider>().bounds.Intersects(transform.GetChild(0).GetComponent<BoxCollider>().bounds))
			{
				rotateSpeed = 5f;
				Destroy (spheres[i].gameObject);
			}
			else if (spheres[i].GetComponent<SphereCollider>().bounds.Intersects(transform.GetChild(1).GetComponent<BoxCollider>().bounds))
			{
				rotateSpeed = -5f;
				Destroy (spheres[i].gameObject);
			}
		}
	}
}
