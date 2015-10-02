using UnityEngine;
using System.Collections;

public class OnContact : MonoBehaviour {

	public Transform player;

	bool attachedPlayer = false;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GetComponent<BoxCollider>().bounds.Intersects(player.GetComponent<SphereCollider>().bounds) && player.GetComponent<Person>().cube != transform && player.GetComponent<Person>().onCube == false)
		{
			player.GetComponent<Person>().onCube = true;
			player.GetComponent<Person>().cube = transform;
			player.transform.parent = transform.GetChild(3);
			player.GetComponent<SphereCollider>().radius = .05f;
            player.transform.rotation = new Quaternion(0, 270, 0, 0);
            player.GetComponent<MouseLook>().OnContact(transform);

        }
    }
}
