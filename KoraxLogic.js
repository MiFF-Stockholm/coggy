#pragma strict

private var coggy : GameObject;
//var flapRate = 0.05;
//var flapForce = 1000000000000000;
//var flapHeight = 0.2;
//private var nextFlap = 0.0;
//var flying = true;
public var speed = 6;
public var attackHeight = 10;

public var leftBorder : Vector3;
//public var rightBorder : Vector3;
private var reachedStart = false;
public var start = false;

function Start () {
	coggy = GameObject.Find("Coggy 1");
	animation.Play();
	audio.Play();
}

function Update () {
	var step = speed * Time.deltaTime;

	if(!start) {
		return;
	}

	if(!reachedStart) {
		Debug.Log("Searching for start");
		var direction = leftBorder - transform.position;	
        
        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, leftBorder, step);
		var rotation  = Quaternion.LookRotation(direction); 
		transform.rotation = rotation;
		
		if(direction.sqrMagnitude < attackHeight*attackHeight) {
			Debug.Log("Reached start!");
			
			reachedStart = true;
		}
	} else {
		Debug.Log("Searching for player");
		//Chase!!		
		var chaseDirection = coggy.transform.position - transform.position;
        
        // If within attackRange
        var attackRange = Mathf.Sqrt(attackHeight*attackHeight + attackHeight/2*attackHeight/2);        
        if(chaseDirection.sqrMagnitude < attackRange*attackRange) {
        	//Within attack range!!! DIVE!!
        	if(!audio.isPlaying) {
        		audio.Play();
        	}
			transform.position = Vector3.MoveTowards(transform.position, coggy.transform.position, step);
			var chaseRotation  = Quaternion.LookRotation(chaseDirection); 
			transform.rotation = chaseRotation;
		} else {
			// Circle....
			var targetPosition = coggy.transform.position;			
			targetPosition.y +=attackHeight;
			
			chaseDirection = targetPosition - transform.position;
			
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
			var circleRotation  = Quaternion.LookRotation(chaseDirection); 
			transform.rotation = circleRotation;
		}	
	}

//	if(flying) {
//		if (flying && Time.time > nextFlap) {
//	        nextFlap = Time.time + flapRate;
//			var sin = Mathf.Sin(Time.time);
//			//Debug.Log("Sin: " + sin);
//			rigidbody.position.y += sin * flapHeight;
//			
//			var child = animation["Armature_001Action"];
//			child.enabled = true;
//			child.wrapMode = WrapMode.ClampForever;
//			animation["Armature_001Action"].wrapMode = WrapMode.Loop;
//			animation.Play("Armature_001Action");
//			Debug.Log("child: " + child);
//		
//		}
//	}
//	
//	if (flying && Time.time > nextFlap) {
//		if(Time.time < nextFlap+flapInterval) {
//			Debug.Log("NEXTFLAP!");
//        	nextFlap = Time.time + flapRate;
//    	}
//    	Debug.Log("FORCE!");
//        //rigidbody.AddForce(Vector3.up*flapForce);
//        //var clone = Instantiate (projectile, transform.position, transform.rotation);
//    }
}

function moveToward(target : Vector3, step) {
	// Move our position a step closer to the target.
    transform.position = Vector3.MoveTowards(transform.position, target, step);    
}

function TriggerStart(payload : boolean) {
	Debug.Log("Korax start message received!");
	start = payload;
}