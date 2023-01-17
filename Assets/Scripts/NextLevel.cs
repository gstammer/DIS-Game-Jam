using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public float nextLevelDelay = 1;

    private float winTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if all coins are gone, move to next level
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        if (coins.Length == 0 && winTime == 0)
            winTime = Time.time;
        if (winTime > 0)
        {
            // freeze rotation & do win animation
            GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
            player.GetComponent<PlayerActions>().winner();
            //GameObject blocks = GameObject.FindGameObjectsWithTag("Rotation")[0];
            //blocks.GetComponent<Rotation>().freeze();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
