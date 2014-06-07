#pragma strict

private var rotating : boolean = false;
public var rotationConst : int = 5;
public var targetName : String;

function Start () {
}

function Update () {
	if(rotating) {
		var go : GameObject = GameObject.Find(targetName);
		go.transform.Rotate(Vector3.up * Time.deltaTime * rotationConst);
	}
}

function OnTriggerEnter(other : Collider) {
	rotating = true;
}
