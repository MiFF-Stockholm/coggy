using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PlayerControl : MonoBehaviour
{
    [HideInInspector]
    public static Vector3 StartPos;

    public LayerMask CanJumpFrom;
    public float JumpForce = 110.0f;
    public float RollForce = 5.0f;
    public float BreakForce = 8.0f;
    public float Radius = 0.8f;
    public float MaxPushVelocity = 10.0f;
    public float MaxPushVelocityAir = 4.0f;
    //public float ClimbForce = 10.0f;

    [HideInInspector]
    public bool Climbing = false;
    [HideInInspector]
    public float ClimbHorizonForce = 0.0f;

    bool dead = false;
    float blockJump = 0.0f;
	bool onGround = false;
	
	bool onSlope = false;

    bool jumpPressed = false;
		
    // Use this for initialization
    void Start()
    {
        Debug.Log("Globals.CheckPointPos " + Globals.CheckPointPos);
        if (Globals.CheckPointPos != Vector3.zero)
            transform.position = Globals.CheckPointPos;

        StartPos = transform.position;
    }
	
	void Update()
	{
		onSlope = false;
		
		onGround = Physics.CheckSphere(transform.position, Radius * 1.2f, CanJumpFrom);
		//Debug.Log("GROUND1 " + onGround);
		
        onGround = onGround && Physics.CheckSphere(transform.position + Vector3.down * Radius * 0.5f, Radius * 1.0f, CanJumpFrom);
		//Debug.Log("GROUND2 " + onGround);
		
        if (onGround)
        {
			RaycastHit hitInfo = new RaycastHit();

            float down = float.PositiveInfinity;
			RaycastHit[] downHits = Physics.RaycastAll(transform.position, Vector3.down, down, CanJumpFrom);
            if (downHits != null && downHits.Length > 0)
            {
				hitInfo = downHits[0];
				foreach(RaycastHit hit in downHits)
				{
					if(hit.distance < hitInfo.distance)
						hitInfo = hit;
						
				}				
				Debug.DrawLine(transform.position, hitInfo.point, Color.green);
                down = hitInfo.distance;
            }

            float left = float.PositiveInfinity;
            RaycastHit[] leftHits = Physics.RaycastAll(transform.position, Vector3.left, left, CanJumpFrom);
            if (leftHits != null && leftHits.Length > 0)
            {
				hitInfo = leftHits[0];
				foreach(RaycastHit hit in leftHits)
				{
					if(hit.distance < hitInfo.distance)
						hitInfo = hit;
						
				}
				float angle = Vector3.Angle(hitInfo.normal, Vector3.left);
				if(angle == 180)
				{
					Debug.DrawLine(transform.position, hitInfo.point, Color.red);
					left = hitInfo.distance;
				}
				else if(hitInfo.distance < down * 1.5f)
				{
					onSlope = true;
				}
            }

            float right = float.PositiveInfinity;
            RaycastHit[] rightHits = Physics.RaycastAll(transform.position, Vector3.right, right, CanJumpFrom);
            if (rightHits != null && rightHits.Length > 0)
            {
				hitInfo = rightHits[0];
				foreach(RaycastHit hit in rightHits)
				{
					if(hit.distance < hitInfo.distance)
						hitInfo = hit;
						
				}
				float angle = Vector3.Angle(hitInfo.normal, Vector3.right);
				if(angle == 180)
				{
					Debug.DrawLine(transform.position, hitInfo.point, Color.red);
                	right = hitInfo.distance;
				}
				else if(hitInfo.distance < down * 1.5f)
				{
					onSlope = true;
				}
            }

            if (down == float.PositiveInfinity)
            {
                if (left < Radius * 1.1f || right < Radius * 1.1f)
                    onGround = false;

            }
            else if (left < down || right < down)
            {
                onGround = false;
            }
			
			
			//Debug.Log("GROUND3 " + onGround);
        }
		
		//Debug.Log("onSlope " + onSlope);
	}
	
    void FixedUpdate()
    {
        if (dead)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            return;
        }

        bool tryingToJump = false;
        if(Input.GetKey(KeyCode.Space)/* .GetButton("Jump")*/)
        {
            if (!jumpPressed)
            {
                tryingToJump = jumpPressed = true;
            }
		}
        else
        {
            jumpPressed = false;
        }

        if (Climbing)
        {
            float climb = Input.GetAxis("Vertical");
            if (climb != 0.0f)
            {
                rigidbody.AddForce(ClimbHorizonForce * RollForce, climb * RollForce, 0.0f);
            }
        }
		
		if(onGround || Climbing)
		{
			if (blockJump > 0.0f)
                blockJump -= Time.fixedDeltaTime;

            if (blockJump <= 0.0f && tryingToJump)
            {
                blockJump = 0.1f;
				if(onSlope)
                	rigidbody.AddForce(0.0f, JumpForce * 1.5f, 0.0f);
				else
					rigidbody.AddForce(0.0f, JumpForce, 0.0f);
				
                playJumpSound();
            }
		}
		
        if (!Climbing && !onGround)
        {
            float push = Input.GetAxis("Horizontal");
            if (push != 0.0f)
            {
                bool breaking = (rigidbody.velocity.x > 0 && push < 0) || (rigidbody.velocity.x < 0 && push > 0);
                if (!breaking)
                {
                    if (Mathf.Abs(rigidbody.velocity.x) >= MaxPushVelocityAir)
                        return;

                }

                if (breaking)
                    rigidbody.AddForce(push * RollForce * 0.25f, 0.0f, 0.0f);
                else
                    rigidbody.AddForce(push * RollForce, 0.0f, 0.0f);

            }
            return;
        }
        else
        {
            float push = Input.GetAxis("Horizontal");
            if (push != 0.0f)
            {
                bool breaking = (rigidbody.velocity.x > 0 && push < 0) || (rigidbody.velocity.x < 0 && push > 0);
                if (!breaking)
                {
                    if (Mathf.Abs(rigidbody.velocity.x) >= MaxPushVelocity)
                        return;

                }

                if (breaking)
                    rigidbody.AddForce(push * BreakForce, 0.0f, 0.0f);
                else
                    rigidbody.AddForce(push * RollForce, 0.0f, 0.0f);

            }
        }
    }

    void playJumpSound()
    {
        AudioSource[] audioArr = GetComponents<AudioSource>();
        //		audioArr[0].Play();

        foreach (AudioSource audiox in audioArr)
        {
            Debug.Log(audiox.clip.name);
            if (audiox.clip.name == "boing 1")
            {
                audiox.Play();
            }
        }

        //		AudioSource myAudio = GetComponents<AudioSource>();
        //		myAudio.Play();
    }

    public void kill()
    {
        dead = true;
        audio.Play();
    }

    void OnGUI()
    {
        if (dead)
        {
            int w = 300;
            int h = 100;
            bool restart = GUI.Button(new Rect((Screen.width - w) / 2, (Screen.height - h) / 2, w, h), new GUIContent("Game Over", "Respawn"));
            if (restart)
            {
                Application.LoadLevel(Application.loadedLevelName);
            }
        }
    }
}
