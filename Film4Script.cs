using UnityEngine;
using System.Collections;

public class Film4Script : MonoBehaviour {

	private int screenIndex = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown() {
		if (screenIndex == 0) {
			screenIndex++;
			GameObject go = GameObject.Find("Plane2");
			go.GetComponent<AudioSource>().Play();
			renderer.material.mainTexture = GameObject.Find("Plane2").renderer.material.mainTexture;
		} else if (screenIndex == 1) {
			screenIndex++;
			renderer.material.mainTexture = GameObject.Find("Plane3").renderer.material.mainTexture;
		} else if (screenIndex == 2) {
			screenIndex++;
			GameObject go = GameObject.Find("Plane4");
			go.GetComponent<AudioSource>().Play();
			renderer.material.mainTexture = GameObject.Find("Plane4").renderer.material.mainTexture;
		} else if (screenIndex == 3) {
			screenIndex++;
			renderer.material.mainTexture = GameObject.Find("Plane5").renderer.material.mainTexture;
		} else if (screenIndex == 4) {
			screenIndex++;
			GameObject go = GameObject.Find("Plane6");
			go.GetComponent<AudioSource>().Play();
			renderer.material.mainTexture = GameObject.Find("Plane6").renderer.material.mainTexture;
		} else if (screenIndex == 5) {
			screenIndex++;
			GameObject go = GameObject.Find("Plane7");
			go.GetComponent<AudioSource>().Play();
			renderer.material.mainTexture = GameObject.Find("Plane7").renderer.material.mainTexture;
		} else if (screenIndex == 6) {
			Application.LoadLevel("level3_engine");
		}
    }
}
