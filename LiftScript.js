#pragma strict

public var destY : float;
public var upwards : boolean;
private var startY : float;

function Start () {
	startY = transform.position.y;
}

function FixedUpdate () {
	var sinus = Mathf.Sin(Time.time);
	
	var newPos = 0f;
	if (upwards) {
		newPos = transform.position.y + sinus/10f;
		if (newPos >= startY && newPos <= destY) {
			transform.position.y = newPos;
		}
	} else {
		newPos = transform.position.y - sinus/10f;
		if (newPos <= startY && newPos >= destY) {
			transform.position.y = newPos;
		}
	}
}