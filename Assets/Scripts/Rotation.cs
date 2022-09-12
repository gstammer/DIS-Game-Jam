using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed = 40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal") * -1;
        Vector3 center = new Vector3(0, 0, 0);
        Vector3 rotationAxis = new Vector3(0, 0, 1);
        transform.RotateAround(center, rotationAxis, input * speed * Time.deltaTime);
    }
}
