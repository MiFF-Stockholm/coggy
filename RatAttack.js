#pragma strict

private var rat : Component;

function Start () {
	rat = GameObject.Find("rat").GetComponent("KoraxLogic");;
}

function OnTriggerEnter(other : Collider) {
	rat.BroadcastMessage("TriggerStart", true);
	Debug.Log("Korax start message sent!");
}

