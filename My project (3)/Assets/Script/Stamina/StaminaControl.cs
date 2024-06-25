using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StaminaControl : MonoBehaviour
{
    PlayerMovement movement;
    public float stamina = 100f;
    public float staminaDepletionRate = 10f;
    public float staminaRecoveryRate = 5f;
    public float maxStamina = 100f;
    public float staminaCooldownTime = 5f;
    public bool isRunning = false;
    public bool isCooldown = false;
    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    void FixedUpdate()
    {
        ManageStamina();
        MovePlayer();
    }
    

    void ManageStamina()
    {
        if (isRunning && stamina > 0)
        {
            stamina -= staminaDepletionRate * Time.fixedDeltaTime;
        }
        else if (!isRunning && stamina < maxStamina)
        {
            stamina += staminaRecoveryRate * Time.fixedDeltaTime;
        }

        stamina = Mathf.Clamp(stamina, 0f, maxStamina);
        if (stamina <= 0 && !isCooldown)
        {
            StartCoroutine(StaminaCooldown());
        }
    }
    IEnumerator StaminaCooldown()
    {
        isCooldown = true;

        yield return new WaitForSeconds(staminaCooldownTime);

        isCooldown = false;
    }
    public bool StaminaValueController(int audioValue)
    {
        return stamina > audioValue ? true : false;
    }
    void MovePlayer()
    {
        if (isRunning && stamina > 0 && movement.walkSpeed <= 10)
        {
            stamina -= staminaDepletionRate * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift) && StaminaValueController(0) && !isCooldown && Input.GetKey(KeyCode.W))
        {
            isRunning = true;
            movement.walkSpeed = 35f;
        }
        else
        {
            movement.walkSpeed = 15f;
            isRunning = false;
        }

    }

}
//if(stamina>0)
//{
//    return true;
//}
//else 
//{
//    return false; 
//}
