using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HPManager : MonoBehaviour
{
    public int madnessDrainSpeed;
    private float madness;
    private GameObject hpDisplayer;
    private TextMeshProUGUI textMesh;
    LightInteractor lightInfo;
    // Start is called before the first frame update
    void Start()
    {
        madness = 0;
        hpDisplayer = GameObject.Find("HPBar");
        textMesh = hpDisplayer.GetComponent<TextMeshProUGUI>();
        lightInfo = GetComponent<LightInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        madness += (0.1f - lightInfo.lightLevel) * madnessDrainSpeed * Time.deltaTime;
        madness = Mathf.Clamp(madness, 0, 100);
        textMesh.text = "Madness: " + (int)madness;
        if (madness == 100)
        {
            SceneManager.LoadScene("GameLoss");
        }
    }
}
