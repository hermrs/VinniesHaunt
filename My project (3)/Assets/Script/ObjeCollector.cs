//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ObjeCollector : MonoBehaviour
//{
//    private ICollectible currentCollectible = null;

//    private void OnTriggerEnter(Collider other)
//    {
//        ICollectible collectible = other.GetComponent<ICollectible>();
//        if (collectible != null)
//        {
//            currentCollectible = collectible;
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        ICollectible collectible = other.GetComponent<ICollectible>();
//        if (collectible != null && collectible == currentCollectible)
//        {
//            currentCollectible = null;
//        }
//    }

//    void Update()
//    {
//        if (currentCollectible != null && Input.GetKeyDown(KeyCode.E))
//        {
//            currentCollectible.Collect();
//            currentCollectible = null;
//        }
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        IDestroyable destroyable = collision.gameObject.GetComponent<IDestroyable>();
//        if (destroyable != null)
//        {
//            destroyable.Destroyable();
//        }
//    }

//}

//public interface ICollectible
//{
//    void Collect();
//}
//public interface IDestroyable
//{
//    void Destroyable();
//}

//public interface IInteractable
//{
//    void Interactable();
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeCollector : MonoBehaviour
{
    private ICollectible currentCollectible = null;
    private IInteractable currentInteractable = null;

    private void OnTriggerEnter(Collider other)
    {
        ICollectible collectible = other.GetComponent<ICollectible>();
        if (collectible != null)
        {
            currentCollectible = collectible;
        }

        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            currentInteractable = interactable;
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

    private void OnTriggerExit(Collider other)
    {
        ICollectible collectible = other.GetComponent<ICollectible>();
        if (collectible != null && collectible == currentCollectible)
        {
            currentCollectible = null;
        }

        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable = null;
        }
    }

    void Update()
    {
        if (currentCollectible != null && Input.GetKeyDown(KeyCode.E))
        {
            currentCollectible.Collect();
            currentCollectible = null;
        }

        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
            currentInteractable = null;
        }
    }
}

public interface ICollectible
{
    void Collect();
}

public interface IInteractable 
{
    void Interact();
}

public interface IDestroyable 
{
    void Destroyable();
}
