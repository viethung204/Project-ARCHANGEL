using UnityEngine;
using UnityEngine.SceneManagement;

// Attach this script to a GameObject in each of your scenes.
// It will automatically save the name of the scene when your scene loads.
// When you want to load the last active scene, call SaveActiveScene.LoadActiveScene().
public class SaveActiveScene : MonoBehaviour
{
    // This will be automatically called when your scene loads.
    void Start()
    {
        // Saves the name of the active scene.
        ES3.Save("activeScene", SceneManager.GetActiveScene().name);
    }
}

