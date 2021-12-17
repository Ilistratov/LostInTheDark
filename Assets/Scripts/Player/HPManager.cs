using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HPManager : MonoBehaviour
{
    public float sanityChangeSpeed;
    private float sanity;
    private SanityDisplayController hpDisplayer;
    LightInteractor lightInfo;
    // Start is called before the first frame update
    void Start()
    {
        sanity = 1;
        hpDisplayer = GameObject.FindGameObjectWithTag("Sanity Display").GetComponent<SanityDisplayController>();
        lightInfo = GetComponent<LightInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        float targetSanity = lightInfo.lightLevel;
        float deltaSanity = targetSanity - sanity;
        float speedMod = Mathf.Sign(deltaSanity);
        if (Mathf.Abs(deltaSanity) < sanityChangeSpeed)
		{
            speedMod = 0;
		}
        if (Mathf.Abs(deltaSanity) > 0.3)
		{
            speedMod *= 2;
		}
        sanity += sanityChangeSpeed * speedMod;
        hpDisplayer.SetValue(sanity);
        if (sanity < 0.005)
        {
            SceneManager.LoadScene("GameLoss");
        }
    }
}
