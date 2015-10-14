using UnityEngine;
using System.Collections;

public class OnContact : MonoBehaviour {

	public Transform player;

	bool attachedPlayer = false;

    public float sphereScaler;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player" && player.GetComponent<Person>().onCube == false)
        {
            Debug.Log("Colliding");
            player.GetComponent<Person>().onCube = true;
            player.GetComponent<Person>().cube = transform;
            player.transform.rotation = new Quaternion(0, 270, 0, 0);
            player.GetComponent<MouseLook>().OnContact(transform);
            Destroy(player.GetComponent<Rigidbody>());
            Destroy(GetComponent<Rigidbody>());
            Debug.Log(GetComponent<BoxCollider>().bounds + "       " + player.GetComponent<SphereCollider>().bounds);
        }
    }
}
