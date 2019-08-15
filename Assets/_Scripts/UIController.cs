using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image HealthBar;
    public Image StaminaBar;

    public PlayerMovementComponent PMC; //short for PlayerMovementComponent


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StaminaBar.fillAmount = PMC.CurrentStamina / PMC.MaxStamina;
    }
}
