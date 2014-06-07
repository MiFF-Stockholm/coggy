using UnityEngine;
using System.Collections;

public class coolkillbox : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		Debug.Log("test");
		PlayerControl player = other.GetComponent<PlayerControl>();
		if(player != null) {
			player.kill();
		}
	}
}
