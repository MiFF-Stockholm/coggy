using UnityEngine;
using System.Collections;

public class PushForward : MonoBehaviour 
{
    public float RollForce = 2.0f;

    Rigidbody body = null;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        float push = Input.GetAxis("Horizontal");
        if (push != 0.0f)
            body.AddForce(push * RollForce, 0.0f, 0.0f);

	}
}
