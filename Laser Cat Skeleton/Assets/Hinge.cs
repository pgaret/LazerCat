using UnityEngine;
using System.Collections;

public class Hinge : MonoBehaviour {

    public Vector3 startingVect;

	// Use this for initialization
	void Start ()
    {
        startingVect = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
  //      Debug.Log(Vector3.Distance(startingVect, transform.position));
        transform.position = startingVect;
	}
}
