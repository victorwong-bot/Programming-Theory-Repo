using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class MenuHandler : MonoBehaviour
{
    // ABSTRACTION
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    // ABSTRACTION
    public void QuitGame()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }
}
