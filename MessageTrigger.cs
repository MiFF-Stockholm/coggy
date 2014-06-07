using UnityEngine;
using System.Collections;

public class MessageTrigger : MonoBehaviour {
	public GameObject Receiver;
	public string OnEnter = "";
	public string OnExit = "";
	
	void OnTriggerEnter(Collider other) 
	{
        if(OnEnter != "")
		{
			if(Receiver == null)
				SendMessage(OnEnter);
			else
				Receiver.SendMessage(OnEnter);
			
		}
    }	
	
	void OnTriggerExit(Collider other) 
	{
        if(OnExit != "")
		{
			if(Receiver == null)
				SendMessage(OnExit);
			else
				Receiver.SendMessage(OnExit);
			
		}
    }
}
