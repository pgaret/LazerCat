using UnityEngine;
using System.Collections;

public class OnContact : MonoBehaviour {

	public Transform player;

	bool attachedPlayer = false;

    void Start()
    {

    }

    void Update()
    {
        //       Debug.Log(Vector3.Distance(transform.GetChild(0).transform.position, transform.position) + "   " + Vector3.Distance(transform.GetChild(1).transform.position, transform.position));

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player" && player.GetComponent<Person>().onCube == false)
        {
//            Debug.Log(Vector3.Distance(transform.GetChild(0).transform.position, player.position) + "  " + Vector3.Distance(transform.GetChild(1).transform.position, player.position));
            if (Vector3.Distance(transform.GetChild(0).transform.position, player.position) > Vector3.Distance(transform.GetChild(1).transform.position, player.position))
            {
                player.GetComponent<Person>().cubeFace = 0;
            }
            else player.GetComponent<Person>().cubeFace = 1;
            player.GetComponent<Person>().cube = transform;
   //         player.GetComponent<PlayerMovement>().orbitRadius = Vector3.Distance(transform.position, player.position);
            Debug.Log(Vector3.Distance(transform.position, player.position));
            player.transform.localEulerAngles = transform.localEulerAngles;
            player.transform.GetChild(0).position = player.transform.localPosition;
            player.GetComponent<MouseLook>().origRot = transform.localEulerAngles;
            player.GetComponent<PlayerMovement>().orbitRadius = Vector3.Distance(transform.GetChild(2).position, player.position);
            Destroy(player.GetComponent<Rigidbody>());
            Destroy(GetComponent<Rigidbody>());
            player.GetComponent<Person>().onCube = true;

        }
    }
}
