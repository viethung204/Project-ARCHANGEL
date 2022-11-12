using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveNextActiveScreen : MonoBehaviour
{
    public string nextLevelLoadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        ES3.Save("activeScene", nextLevelLoadingScreen);
    }
}
