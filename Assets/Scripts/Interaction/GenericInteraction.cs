using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInteraction : MonoBehaviour
{
    private int mInteractionToken = 0;
    public GameObject selectorDisplayPrefab;
    private GameObject selectorDisplay;

    private bool IsProvided()
    {
        return mInteractionToken != 0;
    }
    public virtual bool IsActionAvailable() { return false; } // Default implementation
    public virtual void Interact() { return; } // Default implementation
    public virtual string GetUIString() { return ""; }
    public virtual void OnSelected()
    {
        if (selectorDisplay)
        {
            selectorDisplay.SendMessage("OnSelected", GetUIString(), SendMessageOptions.DontRequireReceiver);
        }
    }
    public virtual void OnDeselected()
    {
        if (selectorDisplay)
        {
            selectorDisplay.SendMessage("OnDeselected", SendMessageOptions.DontRequireReceiver);
        }
    }

    public virtual void Start()
    {
        if (selectorDisplayPrefab)
        {
            selectorDisplay = GameObject.Instantiate(selectorDisplayPrefab, gameObject.transform);
        }
    }

    public virtual void Update()
    {
        if (!IsProvided() && IsActionAvailable())
        {
            var interactor = UnityEngine.GameObject.FindObjectOfType<PlayerInteractor>();
            mInteractionToken = interactor.RegisterInteraction(this);
            if (selectorDisplay)
            {
                selectorDisplay.SendMessage("OnShow", SendMessageOptions.DontRequireReceiver);
            }
        }
        else if (IsProvided() && !IsActionAvailable())
        {
            var interactor = UnityEngine.GameObject.FindObjectOfType<PlayerInteractor>();
            interactor.UnregisterInteraction(mInteractionToken);
            mInteractionToken = 0;
            if (selectorDisplay)
            {
                selectorDisplay.SendMessage("OnHide", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
