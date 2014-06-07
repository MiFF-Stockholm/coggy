using UnityEngine;
using System.Collections;

public class Move1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
        other.rigidbody.velocity = Vector3.zero;
		other.rigidbody.angularVelocity = Vector3.zero;
    }
	
	void OnTriggerStay(Collider other) {
        other.rigidbody.MovePosition(other.transform.position + new Vector3(2.0f * Time.deltaTime, 0, 0));
    }
}
