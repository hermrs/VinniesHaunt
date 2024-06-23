using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapıX : MonoBehaviour, IDestroyable, ITouchable
{
    public void Destroyable()
    {
        if (KeyX.gotTheXKey == true)
        {
            Destroy(gameObject); // Animasyon buraya eklenebilir.
        }
    }

    public void Touch()
    {
        Destroy(gameObject);// Burada başka bir işlem yapabilirsiniz.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pooh")
        {
            // Eğer çarpışan nesne "pooh" tag'ine sahipse Touch metodunu çağır.
            Touch();
        }
    }

    // Eğer trigger ile çalışıyorsanız bu metodu kullanabilirsiniz.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pooh")
        {
            // Eğer çarpışan nesne "pooh" tag'ine sahipse Touch metodunu çağır.
            Touch();
        }
    }

    public void Interact()
    {
        Destroyable();
    }
}