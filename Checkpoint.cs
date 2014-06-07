using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Checkpoint : MonoBehaviour {
	public Swing Pendel;
	
	bool takenEver = false;	
	bool taken = false;	
	float feedbackTime = 1.5f;
	GUIStyle style;
	Rect rect;
	
	void Start()
	{
		style = new GUIStyle();
		style.fontSize = 35;
	
		int w = 300;
		int h = 100;
		rect = new Rect((Screen.width-w)/2, (Screen.height-h)/2 - h * 2, w, h);
	}
	
	void Update()
	{
		if(taken && feedbackTime > 0.0f)
		{
			feedbackTime -= Time.deltaTime;
			if(feedbackTime <= 0.0f)
				taken = false;
			
		}
	}
	
	void OnGUI()
	{
		if(taken)
		{
			GUI.Label(rect, "CHECKPOINT!", style);
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(takenEver)
			return;
		
		PlayerControl player = other.GetComponent<PlayerControl>();
		if(player != null) 
		{
			Pendel.enabled = true;
			takenEver = taken = true;
			Globals.CheckPointPos = other.transform.position;
		}
	}
	
}
