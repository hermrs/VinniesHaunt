using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public static PanelController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OpenPanelWidthKey(GameObject Panel,KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode)) 
        {
            OpenPanel(Panel);
        }
        //if (PanelSetActive(Panel))
        //{
        //    Panel.SetActive(false);
        //}
        //else 
        //{ 
        //    Panel.SetActive(true); 
        
        //}
        
    }
    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
    public bool PanelSetActive(GameObject Panel)
    {
        if (Panel.activeInHierarchy)
        {
            //Panel.SetActive(!Panel.activeSelf);
            return true;
        }
        return false;
    }
}
//public void Interact(GameObject phonePanel)
//{
//    // player ile panel aras�nda bir etkile�im ger�ekle�tir
//    if (phonePanel != null)
//    {
//        phonePanel.SetActive(!phonePanel.activeSelf); // Paneli aktif veya pasif yap
//    }
//}
// PanelOpener aray�z�
public interface PanelOpener
{
    void Interact(GameObject panel);
}
interface IPhoneNumber
{
    void TaskOnClick(int butonnumber);
}