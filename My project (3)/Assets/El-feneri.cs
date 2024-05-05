using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class El_Feneri : MonoBehaviour
{
    public GameObject isik;
    bool isikacikmi;
    // Start is called before the first frame update
    void Start()
    {
        isikacikmi = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isikacikmi = !isikacikmi;
            isik.SetActive(isikacikmi);
        }

    }
}
