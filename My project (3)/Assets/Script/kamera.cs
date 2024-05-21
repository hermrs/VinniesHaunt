using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{

    public Transform Karakter;
    public float mousSpeed;
    float xrot, yrot;
    float minX = -60, maxX = 60;
    // Start is called before the first frame update
    void Start()
    {

    }
    void LateUpdate()
    {
        xrot -= Input.GetAxis("Mouse Y") * Time.deltaTime * mousSpeed;
        yrot += Input.GetAxis("Mouse X") * Time.deltaTime * mousSpeed;
        xrot = Mathf.Clamp(xrot, minX, maxX);
        transform.GetChild(0).localRotation = Quaternion.Euler(xrot, 0, 0);
        transform.localRotation = Quaternion.Euler(0, yrot, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, Karakter.transform.position, 10f);
    }
}
