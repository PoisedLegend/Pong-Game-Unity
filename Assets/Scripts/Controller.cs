using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject playerOne;
    public float speed = 1f;

    public float yRange = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x,-yRange, transform.position.z);
        }

        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.Translate(Vector2.down);
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            //transform.Translate(Vector2.up);
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
    }


    
}
