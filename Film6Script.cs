using UnityEngine;
using System.Collections;

public class Film6Script : MonoBehaviour {

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
			renderer.material.mainTexture = GameObject.Find("Plane2").renderer.material.mainTexture;
		} else if (screenIndex == 1) {
			screenIndex++;
			renderer.material.mainTexture = GameObject.Find("Plane3").renderer.material.mainTexture;
		} else if (screenIndex == 2) {
			screenIndex++;
			renderer.material.mainTexture = GameObject.Find("Plane4").renderer.material.mainTexture;
		} else if (screenIndex == 3) {
			screenIndex++;
			renderer.material.mainTexture = GameObject.Find("Plane5").renderer.material.mainTexture;
		} else if (screenIndex == 4) {
			screenIndex++;
			renderer.material.mainTexture = GameObject.Find("Plane6").renderer.material.mainTexture;
		} else if (screenIndex == 5) {
			screenIndex++;
			renderer.material.mainTexture = GameObject.Find("Plane7").renderer.material.mainTexture;
		} else if (screenIndex == 6) {
			screenIndex++;
			renderer.material.mainTexture = GameObject.Find("Plane8").renderer.material.mainTexture;
		} else if (screenIndex == 7) {
			screenIndex++;
			renderer.material.mainTexture = GameObject.Find("Plane9").renderer.material.mainTexture;
		} else if (screenIndex == 8) {
			screenIndex++;
			renderer.material.mainTexture = GameObject.Find("Plane10").renderer.material.mainTexture;
		} else if (screenIndex == 9) {
			screenIndex++;
			renderer.material.mainTexture = GameObject.Find("Plane11").renderer.material.mainTexture;
		} else if (screenIndex == 10) {
			Application.LoadLevel("credits_scen");
		}
    }
}
