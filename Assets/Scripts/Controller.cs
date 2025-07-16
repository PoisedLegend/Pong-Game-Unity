using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject playerOne;
    public float speed = 1f;
    private GameManager gameManager;
    private float timer = 3f;
    public bool lockControls = false;
    public Color SpikeOn = Color.red;
    public Color SpikeOff = Color.white;
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
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
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

        if (Input.GetKey(KeyCode.D) && !lockControls)
        {
            lockControls = true;
            Renderer myRenderer = GetComponent<Renderer>();
            myRenderer.material.color = SpikeOn;
            StartCoroutine(WaitAfter3Seconds());
        }

        IEnumerator WaitAfter3Seconds()
        {
            Renderer myRenderer = GetComponent<Renderer>();
            yield return new WaitForSeconds(timer); // Adjust the delay as needed
            myRenderer.material.color = SpikeOff;
            lockControls = false;

        }  
    }


    
}
