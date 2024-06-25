using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class DoorControl : MonoBehaviour ,ICollectible,ITouchable
{
    Animator animDoor;
    public AudioSource audioSource;
    private bool isOpen = false;
    private void Start()
    {
        animDoor = GetComponent<Animator>();
    }
    public void Touch()
    {
        if (!isOpen)
        {
            animDoor.SetBool("openDoor", true);
            isOpen = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pooh")
        {
            // Eðer çarpýþan nesne "pooh" tag'ine sahipse Touch metodunu çaðýr.
            Touch();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pooh"))
        {
            if (isOpen)
            {
                animDoor.SetBool("openDoor", false);
                isOpen = false;
            }
        }
    }
    //deneme bir iki 

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Pooh"))
    //    {
    //        bool isOpen = animDoor.GetBool("openDoor");


    //        animDoor.SetBool("openDoor", !isOpen);

    //    }

    //}

    public void Collect()
    {
        bool isOpen = animDoor.GetBool("openDoor");

        animDoor.SetBool("openDoor", !isOpen);

        if (audioSource != null)
        {
            audioSource.Play();
        }

    }

}
