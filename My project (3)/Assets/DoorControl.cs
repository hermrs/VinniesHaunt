using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    Animator animDoor;

    private void Start()
    {
        animDoor = GetComponent<Animator>();
    }

    private void Update()
    {
        KeyCod(); 
    }

    void KeyCod()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            bool isOpen = animDoor.GetBool("openDoor");


            animDoor.SetBool("openDoor", !isOpen);
        }
    }
}
