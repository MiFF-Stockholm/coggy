#pragma strict

private var korax : Component;

function Start () {
	korax = GameObject.Find("Korax").GetComponent("KoraxLogic");;
}

function OnTriggerEnter(other : Collider) {
	korax.BroadcastMessage("TriggerStart", true);
	Debug.Log("Korax start message sent!");
}

