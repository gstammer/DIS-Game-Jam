using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Sprite[] frames;
    public float framesPerSec = 5;
    public AudioClip sound;

    private SpriteRenderer mySR;
    private int currentFrameIndex = 0;
    private float frameTimer;
    private Collider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
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
                currentFrameIndex = 0;
            frameTimer = (1f / framesPerSec);
            mySR.sprite = frames[currentFrameIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        Object.Destroy(gameObject);
    }
}
