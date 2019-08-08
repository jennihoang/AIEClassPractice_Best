using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlComponent : MonoBehaviour {

    public Animator Anim;
    public Rigidbody RB;
    public PlayerMovementComponent Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        
                                       
        Vector3 LocalVelocity = transform.InverseTransformDirection(RB.velocity);

        Anim.SetFloat("HorzSpeed", LocalVelocity.x);
        Anim.SetFloat("VertSpeed", LocalVelocity.z);

        Anim.SetBool("IsSprinting", Player.IsSprinting);

        //Left Click to Activate Animation
        if (Input.GetMouseButtonDown(0))
        {
            Anim.SetTrigger("Punch");
        }

    }

}


