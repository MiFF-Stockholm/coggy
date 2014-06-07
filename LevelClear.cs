using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class LevelClear : MonoBehaviour {
	
	private bool wonLevel = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		wonLevel = true;
		Globals.CheckPointPos = Vector3.zero;
        Globals.CameraOffset = Vector3.zero;
	}
	
	void OnGUI() {
		if(wonLevel) {
			int w = 300;
			int h = 100;
			bool restart = GUI.Button(new Rect((Screen.width-w)/2, (Screen.height-h)/2, w, h), new GUIContent("Congratulations!", "Next level!"));
			Application.LoadLevel("film3_scen");
		}
	}
}
