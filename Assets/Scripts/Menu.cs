using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    /// <summary>
    /// Load given scene
    /// </summary>
    /// <param name="seconds">Seconds.</param>
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
