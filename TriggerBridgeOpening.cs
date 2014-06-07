using UnityEngine;
using System.Collections;

public class TriggerBridgeOpening : MonoBehaviour {
	
	public GameObject drawbridge;
	public float startPos;
	public float maxPos;
	
	private bool openBridge = false;
	private const float MOVEINCR = 0.05f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (openBridge) {
			if (drawbridge.transform.position.x <= maxPos) {
				new WaitForSeconds(15f);
				var newX = drawbridge.transform.position.x + MOVEINCR;
				var oldY = drawbridge.transform.position.y;
				var oldZ = drawbridge.transform.position.z;
				drawbridge.transform.localPosition = new Vector3(newX, oldY, oldZ);
				
			}
		}
	}
	
	// Destroy everything that enters the trigger
	void OnTriggerEnter(Collider other) {
		audio.Play();
		openBridge = true;
    }
}
