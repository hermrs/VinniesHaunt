using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Landmine : MonoBehaviour
{
    public GameObject landmine;

    // Update is called once per frame
    void Update()
    {
        landminesum();
    }

    void landminesum()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Vector3 characterPosition = transform.position;

            Instantiate(landmine, characterPosition, Quaternion.identity);
        }
    }
}
