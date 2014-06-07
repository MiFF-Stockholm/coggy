using UnityEngine;
using System.Collections;

public class winBox : MonoBehaviour {
		
	private bool wonLevel = false;
		
	void OnTriggerEnter(Collider other) {
		wonLevel = true;
		//Globals.CheckPointPos = Vector3.zero;
        //Globals.CameraOffset = Vector3.zero;
	}
	
	void OnGUI() {
		if(wonLevel) {
			int w = 300;
			int h = 100;
			bool restart = GUI.Button(new Rect((Screen.width-w)/2, (Screen.height-h)/2, w, h), new GUIContent("VICTORY!"));
			Application.LoadLevel("film6_scen");
		}
	}
}
