using UnityEngine;
using System.Collections;

public class ClaffMover : MonoBehaviour 
{
	public float RotSpeed = 10.0f;
	
	Quaternion openRotation;
	Quaternion closedRotation;	
	Quaternion targetRotation;
	
	// Use this for initialization
	void Start () {
		targetRotation =  openRotation = Quaternion.Euler(0, 0, 270);
		closedRotation = Quaternion.Euler(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.rotation == targetRotation)
			return;
			
		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotSpeed * Time.deltaTime);
	}
	
	public void Open()
	{
		targetRotation = openRotation;
	}
	
	public void Close()
	{
		targetRotation = closedRotation;
	}
}
