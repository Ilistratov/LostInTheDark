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
    private UnityEngine.UI.Text mInteractionDisplay;

    public void PerfomSelectedInteraction()
    {
        if (mSelectedInteractionIndex < mAvailableInteractions.Count)
        {
            GenericInteraction selectedInteraction =
                mAvailableInteractions.GetByIndex(mSelectedInteractionIndex) as GenericInteraction;
            if (selectedInteraction == null)
            {
                throw new InvalidOperationException(
                    "selectedInteraction wasn't a valid GenericInteraction");
            }
            selectedInteraction.Interact();
        }
    }

    public void SelectNextInteraction()
    {
        mSelectedInteractionIndex += 1;
        if (mSelectedInteractionIndex >= mAvailableInteractions.Count)
        {
            mSelectedInteractionIndex = 0;
        }
        UpdateUIString();
    }

    public int RegisterInteraction(GenericInteraction interaction)
    {
        mAvailableInteractions.Add(mNextRegistrationToken, interaction);
        mNextRegistrationToken += 1;
        UpdateUIString();
        return mNextRegistrationToken - 1;
    }

    public void UnregisterInteraction(int interactionToken)
    {
        if (mSelectedInteractionIndex + 1 == mAvailableInteractions.Count)
        {
            mSelectedInteractionIndex = 0;
        }
        mAvailableInteractions.Remove(interactionToken);
        UpdateUIString();
    }

    void UpdateUIString()
    {
        StringBuilder sb = new StringBuilder(50 * mAvailableInteractions.Count);
        for (int i = 0; i < mAvailableInteractions.Count; i++)
        {
            GenericInteraction interaction = mAvailableInteractions.GetByIndex(i) as GenericInteraction;
            string interactionUIString = interaction.GetInteractionUIString();
            if (i == mSelectedInteractionIndex)
            {
                sb.Append(String.Format(" - {0} <- [E]\n", interactionUIString));
            }
            else
            {
                sb.Append(String.Format(" - {0}\n", interactionUIString));
            }
        }
        mInteractionDisplay.text = sb.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        mAvailableInteractions = new SortedList();
        mNextRegistrationToken = 1;
        mSelectedInteractionIndex = 0;
        mInteractionDisplay = GameObject.FindGameObjectWithTag(
            "Interaction Display").GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
