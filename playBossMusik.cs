using UnityEngine;
using System.Collections;

public class playBossMusik : MonoBehaviour {
	
	public static bool BOSS_MUSIC_ONLY = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter(Collider other) {
        //start boss music
		if (BOSS_MUSIC_ONLY == false) {
			AudioSource[] audioArr = GetComponents<AudioSource>();
			foreach (AudioSource audiox in audioArr) {
				Debug.Log(audiox.clip.name);
				if (audiox.clip.name == "bossmusik (add to regular musik)") {
					audiox.Play();
				}
			}
		}
		
		//disable normal music
		BOSS_MUSIC_ONLY = true;
    }
}
