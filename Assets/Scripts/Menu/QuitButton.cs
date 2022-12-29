using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * <summary> Script to handle when the user clicks the quit button </summary>
 */
public class QuitButton : MonoBehaviour
{
    /**
     * <summary> Closes the application </summary>
     */
    public void Quit()
    {
        // If in the unity editor, stop the game from playing
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                // If in a build, just exit the application 
                Application.Quit();
        #endif
    }
}
