#pragma strict

public var body : Transform;
public var endOfBridge : Transform;
public var startX : float;
public var maxX : float;

function Start () {
	body = GameObject.Find("bridge1").GetComponent(Transform);
	endOfBridge = GameObject.Find("endOfBridge").GetComponent(Transform);
	startX = body.position.x;
	maxX = endOfBridge.position.x + endOfBridge.transform.localScale.x + 0.5;
	//player = GameObject.Find("Coggy 1").GetComponent(Transform);
}

function Update () {
	var sinus = Mathf.Sin(Time.time);
	
	var newPos = body.position.x - sinus/10;
	if (newPos <= startX && newPos >= maxX) {
		body.position.x = newPos;
	}
	
	//Physics.Raycast(transform.position, Vector3.down, 5.0f))
	
}