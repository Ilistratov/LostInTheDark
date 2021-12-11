using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
    private void OnEnter()
    {
        SceneManager.LoadScene("GameWin");
    }
}
