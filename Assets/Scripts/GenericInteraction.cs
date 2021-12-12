using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInteraction : MonoBehaviour
{
    private int mInteractionToken = 0;
    private GameObject interactionPointer;
    private InteractionPointerController interactionPointerController;
    private bool IsProvided()
    {
        return mInteractionToken != 0;
    }
    public virtual bool IsProvideRequired() { return false; } // Default implementation
    public virtual bool IsRevokeRequired() { return false; } // Default implementation
    public virtual void Interact() { return; } // Default implementation
    public virtual string GetInteractionUIString() { return "Unnamed interaction"; }
    public virtual void OnSelected() {
        GameObject tooltip = GameObject.FindGameObjectWithTag("Interaction Display");
        TooltipController tooltipController = tooltip.GetComponent<TooltipController>();
        tooltipController.SetText(System.String.Format("[E] - {0}", GetInteractionUIString()));
        tooltipController.Show();
        interactionPointerController.SetActive();
    }
    public virtual void OnDeselected() {
        GameObject tooltip = GameObject.FindGameObjectWithTag("Interaction Display");
        TooltipController tooltipController = tooltip.GetComponent<TooltipController>();
        tooltipController.Hide();
        tooltipController.SetText("");
        interactionPointerController.SetInactive();
    }

	public virtual void Start()
	{
        interactionPointer = GameObject.Instantiate(GameObject.FindGameObjectWithTag("Interaction Pointer"));
        interactionPointer.tag = "Untagged";
        interactionPointer.transform.SetParent(gameObject.transform, false);
        interactionPointerController = interactionPointer.GetComponent<InteractionPointerController>();
    }

	public virtual void Update()
    {
        if (!IsProvided() && IsProvideRequired())
        {
            var interactor = UnityEngine.GameObject.FindObjectOfType<PlayerInteractor>();
            mInteractionToken = interactor.RegisterInteraction(this);
            interactionPointerController.Show();
        }
        else if (IsProvided() && IsRevokeRequired())
        {
            interactionPointerController.Hide();
            var interactor = UnityEngine.GameObject.FindObjectOfType<PlayerInteractor>();
            interactor.UnregisterInteraction(mInteractionToken);
            mInteractionToken = 0;
        }
    }
}
