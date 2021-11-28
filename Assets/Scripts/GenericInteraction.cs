using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInteraction : MonoBehaviour
{
	public virtual bool IsProvideRequired() { return false; } // Default implementation
	public virtual bool IsRevokeRequired() { return false; } // Default implementation
	public virtual void Interact() { return; } // Default implementation
	
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
