using UnityEngine;
using System.Collections;

public class Kuggstang : MonoBehaviour {

    public string PlayerObjectName = "Coggy 1";	
    
    PlayerControl playerControl;
    Rigidbody playerBody;
    RigidbodyConstraints startConstrains;
	
	// Use this for initialization
	void Start () 
    {
        GameObject go = GameObject.Find(PlayerObjectName);
        playerControl = go.GetComponent<PlayerControl>();
        playerBody = go.GetComponent<Rigidbody>();
        startConstrains = playerBody.constraints;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void OnCollisionStay(Collision collision)
    {
		if(!playerControl.Climbing)
			audio.Play();
		
        playerControl.Climbing = true;
		if(collision.transform.position.x > transform.position.x)
			playerControl.ClimbHorizonForce = -1;
		else
			playerControl.ClimbHorizonForce = 1;
			
		//playerControl.ClimbHorizonForce = 
        //playerBody.constraints = RigidbodyConstraints.FreezePositionX;
    }

    void OnCollisionExit(Collision collision)
    {
		if(audio.isPlaying)
			audio.Pause();
		
        playerControl.Climbing = false;
		playerControl.ClimbHorizonForce = 0;
        //playerBody.constraints = startConstrains;
    }
}
