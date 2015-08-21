using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	public float rotateSpeed;

	bool rotating = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (rotating) transform.Rotate(Vector3.right*Time.deltaTime*rotateSpeed);

		GameObject[] spheres = GameObject.FindGameObjectsWithTag ("Sphere");
		for (int i = 0; i < spheres.Length; i++)
		{
			Debug.Log (spheres.Length);
			if (spheres[i].GetComponent<SphereCollider>().bounds.Intersects(gameObject.GetComponent<BoxCollider>().bounds))
			{
				Destroy(spheres[i].gameObject);
				rotating = true;
			}
		}
	}
}
