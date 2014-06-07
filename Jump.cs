using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour 
{
    public LayerMask CanJumpFrom;
    public float Radius = 1.01f;
    public float JumpForce = 250.0f;

    Rigidbody body = null;
    bool block = false;

	// Use this for initialization
	void Start () 
    {
        body = GetComponent<Rigidbody>();
	}

	void FixedUpdate () 
    {
        if (block)
            block = !Physics.Raycast(transform.position, Vector3.down, Radius, CanJumpFrom);

        if (!block && Input.GetButtonDown("Jump"))
        {
            block = true;
            body.AddForce(0.0f, JumpForce, 0.0f);
        }
	}
}
