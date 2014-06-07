#pragma strict

public var body : Transform;

function Start () {
	body = GameObject.Find("Sphere").GetComponent(Transform);
}

function Update () {
	//body.velocity = Vector3(0,1,1);
	var mod = (Time.time)%2;
	var mod2 = (Time.time*10)%11;
	//body.transform.tr
	//Vector3(0.0,0.0,mod-500	);
	
	var sinus = Mathf.Sin(Time.time);
	
	//body.Translate(Vector3(sinus/2, sinus/4, 0.0));
	body.position.x += sinus/10;
	
//	if(sinus/10 < 0) {
//		body.position.y += sinus/10;
//	} else {
//		body.position.y -= sinus/10;
//	}
	//body.position.y += sinus/10 - sinus/20;
	
	
	
//	
//	if(mod < 1) {
//		body.Translate(Vector3(0.1, 0.0, 0.0));
//	} else {
//		body.Translate(Vector3(-0.1, 0.0, 0.0));
//	}
	
//	if(mod%5 < 5) {
//		body.Translate(Vector3(0.0, mod, 0.0));
//	} else {
//		body.Translate(Vector3(0.0, -mod, 0.0));
//	}
	
	
	Debug.Log(sinus);
	Debug.Log(body.position);
	//yield WaitForSeconds(3);
}