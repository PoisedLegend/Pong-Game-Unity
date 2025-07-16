using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2 : MonoBehaviour
{
    public float yRange;
    public float speed = 10f;

    private float timer = 3f;
    public Color SpikeOn = Color.red;
    public Color SpikeOff = Color.white;

    public bool lockControls = false;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
       
        
         if (transform.position.y < -yRange)
            {
            transform.position = new Vector3(transform.position.x,-yRange, transform.position.z);
            }

        if (transform.position.y > yRange)
            {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
            }

        if (Input.GetKey(KeyCode.DownArrow))
            {
            //transform.Translate(Vector2.down);
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            }

        if (Input.GetKey(KeyCode.UpArrow))
            {
            //transform.Translate(Vector2.up);
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
        
        if (Input.GetKey(KeyCode.LeftArrow)&& !lockControls)
        {
            lockControls = true;
            Renderer myRenderer = GetComponent<Renderer>();
            myRenderer.material.color = SpikeOn;
            //myRenderer.material.color = SpikeOff;
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
