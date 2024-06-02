using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeCollector : MonoBehaviour
{
    private ICollectible currentCollectible = null;

    private void OnTriggerEnter(Collider other)
    {
        ICollectible collectible = other.GetComponent<ICollectible>();
        if (collectible != null)
        {
            currentCollectible = collectible;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ICollectible collectible = other.GetComponent<ICollectible>();
        if (collectible != null && collectible == currentCollectible)
        {
            currentCollectible = null;
        }
    }

    void Update()
    {
        if (currentCollectible != null && Input.GetKeyDown(KeyCode.E))
        {
            currentCollectible.Collect();
            currentCollectible = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDestroyable destroyable = collision.gameObject.GetComponent<IDestroyable>();
        if (destroyable != null)
        {
            destroyable.Destroyable();
        }
    }

}

public interface ICollectible
{
    void Collect();
}
public interface IDestroyable
{
    void Destroyable();
}
