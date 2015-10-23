using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float playerSpeed;
    public float orbitRadius;
    Vector3 desiredPosition;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (GetComponent<Person>().onCube == true)
        {
//          Debug.Log("We're rotating");
//            Debug.Log(Vector3.Distance(GetComponent<Person>().cube.GetChild(2).transform.position, transform.position));
//          Debug.Log(GetComponent<Person>().cube.GetChild(2).localPosition);
            transform.RotateAround(GetComponent<Person>().cube.GetChild(2).transform.position, Vector3.up, GetComponent<Person>().cube.GetComponent<Cube>().rotateSpeed);
            desiredPosition = (transform.position - GetComponent<Person>().cube.GetChild(2).transform.position).normalized * orbitRadius + GetComponent<Person>().cube.GetChild(2).transform.position;
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * playerSpeed);

        }

		else if (Input.GetKey(KeyCode.W))
		{
//          Debug.Log("We're moving forwards");
			transform.position += transform.GetChild(0).GetComponent<Camera>().transform.forward * playerSpeed * Time.deltaTime;
		}
       
	}

    void FixedUpdate()
    {


    }
}
