using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInteraction : MonoBehaviour
{
	private int mInteractionToken;
	private bool IsProvided() {
		return mInteractionToken != 0;
	}
	public virtual bool IsProvideRequired() { return false; } // Default implementation
	public virtual bool IsRevokeRequired() { return false; } // Default implementation
	public virtual void Interact() { return; } // Default implementation
	
	void Start()
	{
		mInteractionToken = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (!IsProvided() && IsProvideRequired())
		{
			var interactor = UnityEngine.GameObject.FindObjectOfType<PlayerInteractor>();
			mInteractionToken = interactor.RegisterInteraction(this);
		}
		else if (IsProvided() && IsRevokeRequired())
		{
			var interactor = UnityEngine.GameObject.FindObjectOfType<PlayerInteractor>();
			interactor.UnregisterInteraction(mInteractionToken);
		}
	}
}
