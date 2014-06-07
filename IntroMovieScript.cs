using UnityEngine;
using System.Collections;

public class IntroMovieScript : MonoBehaviour {
	
	private int screenIndex = 0;
	private GameObject introBild2;
	private GameObject introBild3;
	private GameObject introBild4;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown() {
		if (screenIndex == 0) {
			screenIndex++;
			renderer.material.mainTexture = GameObject.Find("Bild2").renderer.material.mainTexture;
		} else if (screenIndex == 1) {
			screenIndex++;
			renderer.material.mainTexture = GameObject.Find("Bild3").renderer.material.mainTexture;
		} else if (screenIndex == 2) {
			screenIndex++;
			renderer.material.mainTexture = GameObject.Find("Bild4").renderer.material.mainTexture;
		} else if (screenIndex == 3) {
			screenIndex++;
			renderer.material.mainTexture = GameObject.Find("Bild5").renderer.material.mainTexture;
		} else if (screenIndex == 4) {
			Application.LoadLevel("level1_clocktower");
		}
    }
}
