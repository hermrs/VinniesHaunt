using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
 
}

// PanelOpener aray�z�
public interface PanelOpener
{
    void Interact(GameObject panel);
}
interface IPhoneNumber
{
    void TaskOnClick(int butonnumber);
}