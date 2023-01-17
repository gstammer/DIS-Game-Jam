using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerActions : MonoBehaviour
{
    public Sprite upSprite;
    public Sprite winSprite;
    public float upForce = 5;
    public float coolDownTime = 1;
    public float spriteRevertTime = 0.5f;
    public GameObject Poof;
    public float poofOffset = 0.5f;
    public float deathSpeed = 50;
    public float deathTime = 0.5f;

    private SpriteRenderer mySR;
    private Rigidbody2D myRB2D;
    private Sprite mainSprite;
    private float lastJetTime = 0;
    private bool dying;
    private float timeAtDeath = 0;
    private bool winning;

    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        myRB2D = GetComponent<Rigidbody2D>();
        mainSprite = mySR.sprite;
        dying = false;
        winning = false;
    }

    // Update is called once per frame
    void Update()
    {
        // player is dying if they hit a killer object
        if (dying)
        {
            // if death timer is up
            if (Time.time - timeAtDeath >= deathTime)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            myRB2D.velocity = new Vector2(0, 0);
            transform.Rotate(new Vector3(0, 0, -deathSpeed * Time.deltaTime));
            transform.localScale = transform.localScale * 0.98f;
        }

        // check jetpack cooldown
        bool jetReady = false;
        if (lastJetTime == 0 || Time.time - coolDownTime >= lastJetTime)
            jetReady = true;

        // press space -> jetpack upwards
        if (Input.GetKeyDown(KeyCode.Space) && jetReady)
        {
            Vector2 upDirection = transform.up;
            upDirection.Normalize();
            Vector2 force = upDirection * upForce;
            myRB2D.AddForce(force, ForceMode2D.Impulse);

            mySR.sprite = upSprite;
            lastJetTime = Time.time;
            Vector3 poofPosition = transform.position - (Vector3)upDirection * poofOffset;
            Instantiate(Poof, poofPosition, transform.rotation);
        }

        if (Time.time - spriteRevertTime >= lastJetTime)
            mySR.sprite = mainSprite;

        if (winning)
        {
            myRB2D.velocity = new Vector2(0, 0);
            mySR.sprite = winSprite;
        }
    }

    public void die()
    {
        dying = true;
        timeAtDeath = Time.time;
    }

    public void winner()
    {
        winning = true;
    }
}
