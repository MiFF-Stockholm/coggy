#pragma strict

private var coggy : GameObject;
private var oldConstraints;
private var holdsCoggy = false;
private var rotation;

function Start () {
	coggy = GameObject.Find("Coggy 1");
	rotation = Quaternion.Euler(90, 0, 0);
}

function OnTriggerEnter(other : Collider) {
	// Lock coggy
	oldConstraints = coggy.rigidbody.constraints;
	//Debug.Log("Before: " + oldConstraints);
	coggy.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
	
	holdsCoggy = true;
	

	
	// Move coggy
	//rigidbody.position
//	var mesh : Mesh = coggy.GetComponent(MeshFilter).mesh;
//	var center : Vector3 = mesh.bounds.center;
//	var radius = coggy.transform.position.
//	coggy.rigidbody.position.x = center.x;
//	coggy.rigidbody.position.y = center.y;
	//Debug.Log(GetComponent(MeshFilter).mesh.bounds.center);
	//Debug.Log(GetComponent(MeshFilter).mesh.bounds);
//	var rotation:Quaternion = transform.rotation;
//	var distance : float = 0.0;
//    var position = transform.position + (rotation *Vector3.back * distance);
//
//    coggy.transform.position = position; 
	var pos = transform.position;
	// MAGIC!! 
	pos.y += 0.95;
	//pos.z += 0.1;
	coggy.transform.position = pos; 
	coggy.rigidbody.MovePosition(pos);
	// Animate
	animation.Play();
	coggy.transform.RotateAround(Vector3.forward , 30*Time.deltaTime);
}

function Update() {
	if(oldConstraints != null && holdsCoggy && !animation.isPlaying) {
		coggy.transform.position.z = 0;
		coggy.rigidbody.constraints = oldConstraints;
		Debug.Log("After: " + oldConstraints);
		/*coggy.transform.rotation.Set(0, 0, 0, 0);
		*/
		
		//coggy.rigidbody.MovePosition(Vector3(coggy.transform.position.x, coggy.transform.position.y, 0));
		//coggy.transform.rotation = rotation;
		oldConstraints = null;
		holdsCoggy = false;
	} else if(holdsCoggy) {
		coggy.rigidbody.velocity = Vector3.zero;
		coggy.rigidbody.angularVelocity = Vector3.zero;
	}
}