using UnityEngine;
using System.Collections;

public class Swing : MonoBehaviour {
	
	public float Speed = 40.0f;
	
	Quaternion left;
	Quaternion right;
	Quaternion target;
	
	// Use this for initialization
	void Start () {
		audio.Play();
		target = left = Quaternion.Euler(240, 90, -90);
		right = Quaternion.Euler(300, 90, -90);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(target == transform.rotation)
		{
			if(target == left)
				target = right;
			else
				target = left;
			
		}
		
		transform.rotation = Quaternion.RotateTowards(transform.rotation, target, Speed * Time.deltaTime);
	}
}
