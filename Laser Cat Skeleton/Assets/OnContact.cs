using UnityEngine;
using System.Collections;

public class OnContact : MonoBehaviour {

	public Transform player;

	bool attachedPlayer = false;

    public float sphereScaler;

	// Use this for initialization
	void Start ()
	{
//        player.transform.localScale = new Vector3(sphereScaler, sphereScaler, sphereScaler);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GetComponent<BoxCollider>().bounds.Intersects(player.GetComponent<SphereCollider>().bounds) && player.GetComponent<Person>().cube != transform && player.GetComponent<Person>().onCube == false)
		{
			player.GetComponent<Person>().onCube = true;
			player.GetComponent<Person>().cube = transform;
            player.transform.parent = transform;
            player.transform.rotation = new Quaternion(0, 270, 0, 0);
            player.GetComponent<MouseLook>().OnContact(transform);
            player.localScale = new Vector3(sphereScaler / transform.localScale.x, sphereScaler / transform.localScale.y, sphereScaler / transform.localScale.z);

        }
    }
}
