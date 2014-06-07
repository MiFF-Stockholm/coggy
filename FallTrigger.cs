using UnityEngine;
using System.Collections;

public class FallTrigger : MonoBehaviour 
{
	public float Timer = 1.0f;
	public float FallToY = -100;
	public float FallAcc = 20.0f;
	
	float fallSpeed = 0.0f;
	public bool timerActive = false;
	GameObject parent;
    bool coggyOn = false;
	
	void Start()
	{
		parent = gameObject.transform.parent.gameObject;		
	}
	
	void Update()
	{
		if(!timerActive)
			return;
		
		Timer -= Time.deltaTime;
		if(Timer <= 0.0f)
		{
			fallSpeed += FallAcc * Time.deltaTime;
			parent.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y - fallSpeed * Time.deltaTime, parent.transform.position.z);
            parent.collider.enabled = coggyOn;
			if(transform.position.y < FallToY)
			{
				GameObject.Destroy(gameObject);
				GameObject.Destroy(parent);
				return;
			}
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
        if (other.GetComponent<PlayerControl>() != null)
        {
            coggyOn = true;
            timerActive = true;
        }	
	}
    
    void OnTriggerExit(Collider other)
	{
        if (other.GetComponent<PlayerControl>() != null)
        {
            coggyOn = false;
            timerActive = true;
        }
	}
}
