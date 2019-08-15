using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour
{


    /// /////////////////////////////////////////////////


    string ShirtColor;

    Material MatRed, MatYellow, MatBlue;
    Material CurrentMat;

    //[SerializeField]
    //private int num = 2;

    //public float fl = 1.4f;

    //private int[] arr;

    //public char character = 'A';

    //public string str = "I am a string";


    // Start is called before the first frame update

    public float SprintSpeed = 500, Walkspeed = 1000;

    private float CurrentSpeed;

    private Rigidbody RB;

    public Vector3 IP;

    public Camera MyMainCamera;

    public bool IsSprinting;
    public float StaminaReductionSpeed;
    public float CurrentStamina, MaxStamina;

    public bool Punch;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        CurrentStamina = MaxStamina;
    }

    public void DoMovement()
    {


        IP.x = Input.GetAxisRaw("Horizontal");
        IP.z = Input.GetAxisRaw("Vertical");

        //RB.AddForce(IP * Speed * Time.deltaTime);
        RB.velocity = new Vector3(IP.x * CurrentSpeed * Time.deltaTime,
                                  RB.velocity.y,
                                  IP.z * CurrentSpeed * Time.deltaTime);
    }
    public void DoMouseLook()
    {
        if (MyMainCamera != null)
        {
            // starts out empty after raycast it is filled with hit info
            RaycastHit LaserPointerHit;
            Ray LaserRay = MyMainCamera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(LaserRay, out LaserPointerHit, 1000.0f);
            Vector3 PointDirectionFromPlayer = (LaserPointerHit.point - transform.position).normalized;
            PointDirectionFromPlayer.y = 0;
            transform.forward = PointDirectionFromPlayer;
        }
    }


    // Update is called once per frame
    void Update()
    {
        IsSprinting = Input.GetKey(KeyCode.LeftShift);
        Debug.Log(transform.forward);
        DoMouseLook();

        if (IsSprinting && CurrentStamina > 0)
        {
            CurrentSpeed = SprintSpeed;
            CurrentStamina -= Time.deltaTime * StaminaReductionSpeed;
        }
        else
        {
            if (CurrentStamina < MaxStamina)
            { 
            CurrentStamina += Time.deltaTime + StaminaReductionSpeed;
            }
            CurrentSpeed = Walkspeed;
        }

        // Current speed changes to sprint or walk speed when sprinting is true or false
        // CurrentSpeed = (IsSprinting == true) ? SprintSpeed : Walkspeed;

        DoMovement();

    }
    public void StepEvent()
    {
        Debug.Log("StepEvent");

    }

    public void StartDamage()
    {
        //Activate Hitbox
        Debug.Log("StartDamage");
    }

    public void EndDamage()
    {
        //Deactivate Hitbox
        Debug.Log("EndDamage");
    }


}


