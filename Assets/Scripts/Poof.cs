using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poof : MonoBehaviour
{
    public Sprite[] frames;
    public float framesPerSec = 5;

    private SpriteRenderer mySR;
    private int currentFrameIndex = 0;
    private float frameTimer;

    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        frameTimer = (1f / framesPerSec);
    }

    // Update is called once per frame
    void Update()
    {
        // animate coin spinning
        frameTimer -= Time.deltaTime;
        if (frameTimer <= 0)
        {
            currentFrameIndex++;
            if (currentFrameIndex >= frames.Length)
            {
                Destroy(gameObject);
                return;
            }
            frameTimer = (1f / framesPerSec);
            mySR.sprite = frames[currentFrameIndex];
        }
    }

}