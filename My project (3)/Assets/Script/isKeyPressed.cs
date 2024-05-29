using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isKeyPressed : MonoBehaviour
{
    public bool EKeyPressed=false;
    void Update()
    {
        isKeyEPressed();
    } 
    public void isKeyEPressed()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EKeyPressed = true;
            Debug.Log("edo");
        }
        else
        {
            EKeyPressed = false;
        }
    }

}
