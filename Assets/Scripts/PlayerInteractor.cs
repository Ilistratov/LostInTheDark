using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private SortedList mAvailableInteractions;
    private int mNextRegistrationToken;
    private int mSelectedInteractionIndex;

    GenericInteraction GetSelectedInteraction()
    {
        if (mSelectedInteractionIndex >= mAvailableInteractions.Count)
        {
            return null;
        }
        var listObject = mAvailableInteractions.GetByIndex(mSelectedInteractionIndex);
        GenericInteraction interaction = listObject as GenericInteraction;
        if (!interaction)
        {
            throw new InvalidOperationException(
                    "selectedInteraction wasn't a valid GenericInteraction");
        }
        return interaction;
    }

    public void PerfomSelectedInteraction()
    {
        GenericInteraction interaction = GetSelectedInteraction();
        if (interaction)
		{
            interaction.Interact();
        }
    }

    public void SelectNextInteraction()
    {
        GenericInteraction oldInteraction = GetSelectedInteraction();
        if (oldInteraction)
		{
            oldInteraction.OnDeselected();
		}
        mSelectedInteractionIndex += 1;
        if (mSelectedInteractionIndex >= mAvailableInteractions.Count)
        {
            mSelectedInteractionIndex = 0;
        }
        GenericInteraction newInteraction = GetSelectedInteraction();
        if (newInteraction)
		{
            newInteraction.OnSelected();
		}
    }

    public int RegisterInteraction(GenericInteraction interaction)
    {
        mAvailableInteractions.Add(mNextRegistrationToken, interaction);
        mNextRegistrationToken += 1;
        if (mAvailableInteractions.Count == 1)
		{
            GetSelectedInteraction().OnSelected();
		}
        return mNextRegistrationToken - 1;
    }

    public void UnregisterInteraction(int interactionToken)
    {
        int removedInteractionIndex = mAvailableInteractions.GetKeyList().IndexOf(interactionToken);
        if (removedInteractionIndex <= mSelectedInteractionIndex)
		{
            GetSelectedInteraction().OnDeselected();
		}
        mAvailableInteractions.Remove(interactionToken);
        if (removedInteractionIndex <= mSelectedInteractionIndex)
        {
            --mSelectedInteractionIndex;
            if (mSelectedInteractionIndex < 0)
			{
                mSelectedInteractionIndex = 0;
			}
            GenericInteraction selectedInteraction = GetSelectedInteraction();
            if (selectedInteraction)
			{
                selectedInteraction.OnSelected();
			}
        }
    }

    void Start()
    {
        mAvailableInteractions = new SortedList();
        mNextRegistrationToken = 1;
        mSelectedInteractionIndex = 0;
    }
}
