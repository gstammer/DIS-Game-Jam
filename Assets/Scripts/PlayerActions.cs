using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Sprite upSprite;
    public float upForce = 5;
    public float coolDownTime = 1;
    public float spriteRevertTime = 0.5f;
    public GameObject Poof;
    public float poofOffset = 0.5f;

    private SpriteRenderer mySR;
    private Rigidbody2D myRB2D;
    private Sprite mainSprite;
    private float lastJetTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        myRB2D = GetComponent<Rigidbody2D>();
        mainSprite = mySR.sprite;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
