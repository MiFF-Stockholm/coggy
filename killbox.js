#pragma strict

var goto : String = "";

function Start () {
	if(goto == "") {
		goto = Application.loadedLevelName;
	}
}

function Update () {

}

function OnTriggerEnter (other : Collider) {
	if(other.name == "Coggy 1") {
		Destroy(other.gameObject);
		playSound();
		yield WaitForSeconds(5);
    	Application.LoadLevel(goto);
    }
}

function playSound() {
	var aSources = GetComponents(AudioSource);
	for	(var audiox : AudioSource in aSources) {
		if (audiox.clip.name == "fallande ljud") {
			audiox.Play();
		}
	}
}