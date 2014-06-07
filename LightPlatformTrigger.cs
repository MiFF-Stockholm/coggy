using UnityEngine;
using System.Collections;

public class LightPlatformTrigger : MonoBehaviour {
	
	Collider parentCollider;
	
	// Use this for initialization
	void Start () {
		parentCollider = transform.parent.collider;		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) 
	{
		parentCollider.enabled = (other.transform.position.y > transform.position.y);
    }	
	
	void OnTriggerExit(Collider other) 
	{
		parentCollider.enabled = (other.transform.position.y > transform.position.y);
    }
}
