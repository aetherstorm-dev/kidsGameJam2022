using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenButton : MonoBehaviour
{
    public string locale;

    public void Trigger()
    {
        Debug.Log("Loading scene with locale " + locale);
        PlayerPrefs.SetString("selected-locale", locale);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
