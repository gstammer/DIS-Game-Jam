using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GameObject[] music = GameObject.FindGameObjectsWithTag("gameMusic");
        if (music.Length > 1) Destroy(music[1]);
    }
}
