using UnityEngine;
using System.Collections;

public class TriggerDoorOpeningVertical : MonoBehaviour {
	
	public GameObject drawbridge;
	public float startPos;
	public float maxPos;
	
	private bool openBridge = false;
	private const float SPEED = 1f;
	public bool upwards = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (openBridge) {
			if (upwards) {
				if (drawbridge.transform.localPosition.y <= maxPos) {
					Debug.Log(SPEED * Time.deltaTime);
					var newY = drawbridge.transform.position.y + SPEED * Time.deltaTime;
					var oldX = drawbridge.transform.position.x;
					var oldZ = drawbridge.transform.position.z;
					drawbridge.transform.localPosition = new Vector3(oldX, newY, oldZ);
				}
			} else {
				if (drawbridge.transform.localPosition.y >= maxPos) {
					Debug.Log(SPEED * Time.deltaTime);
					var newY = drawbridge.transform.position.y - SPEED * Time.deltaTime;
					var oldX = drawbridge.transform.position.x;
					var oldZ = drawbridge.transform.position.z;
					drawbridge.transform.localPosition = new Vector3(oldX, newY, oldZ);
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		openBridge = true;
		audio.Play();
	}
}
