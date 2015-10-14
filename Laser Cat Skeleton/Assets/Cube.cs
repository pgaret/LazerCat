using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	public float setrotateSpeed;
	public float rotateSpeed = 0;
    public Transform toFollow;

	Vector3 axisofRotation = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start ()
	{
		axisofRotation = transform.GetChild (2).transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.RotateAround(axisofRotation, Vector3.up, rotateSpeed);
//        if (rotateSpeed != 0) Debug.Log(transform.position.x.ToString("F4") + "  " + transform.position.y.ToString("F4") + "   " +  transform.position.z.ToString("F4"));
        if (toFollow != null) transform.position = toFollow.position;

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
	}
}
