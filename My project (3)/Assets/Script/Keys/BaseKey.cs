using UnityEngine;
using UnityEngine.UI;
public abstract class BaseKey : MonoBehaviour, ICollectible, IInteractable
{
    public bool GotKey { get; protected set; } = false;

    public virtual void Collect()
    {
        GotKey = true;
        GameManager.Instance.OnKeyCollected();
        UIManager.Instance.UpdateKeyImage(GetKeyImage());
        Destroy(gameObject);
    }

    public void Interact()
    {
        Collect();
    }

    public void Destroyable()
    {
        if (GotKey)
        {
            Destroy(gameObject);
        }
    }

    protected abstract Image GetKeyImage();
}
