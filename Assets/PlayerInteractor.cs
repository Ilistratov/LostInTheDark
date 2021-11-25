using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private SortedList mAvailableInteractions;
    private int mNextRegistrationToken;
    private int mSelectedInteractionIndex;

    public void PerfomSelectedInteraction() {
        if (mSelectedInteractionIndex < mAvailableInteractions.Count) {
            mAvailableInteractions.GetByIndex(mSelectedInteractionIndex);
        }
    }
    
    public void SelectNextInteraction() {
        mSelectedInteractionIndex += 1;
        if (mSelectedInteractionIndex == mAvailableInteractions.Count) {
            mSelectedInteractionIndex = 0;
        }
    }
    
    public int RegisterInteraction(GenericInteraction interaction) {
        mAvailableInteractions.Add(mNextRegistrationToken, interaction);
        mNextRegistrationToken += 1;
        return mNextRegistrationToken - 1;
    }
    
    public void UnregisterInteraction(int interactionToken) {
        if (mSelectedInteractionIndex + 1 == mAvailableInteractions.Count) {
            mSelectedInteractionIndex = 0;
        }
        mAvailableInteractions.Remove(interactionToken);
    }

    // Start is called before the first frame update
    void Start()
    {
        mAvailableInteractions = new SortedList();
        mNextRegistrationToken = 1;
        mSelectedInteractionIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
