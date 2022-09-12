using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        if (coins.Length == 0)
            SceneManager.LoadScene("Level2");
    }
}
