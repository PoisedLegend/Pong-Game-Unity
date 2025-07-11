using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject ball;
    public GameManager gameManager;
    private Vector3 startPosition;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (ball ?? false)
        {
            //Move Up
            if (ball.transform.position.y > transform.position.y)
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);

                //if (transform.position.y > startPosition.y)
                //{
                    
                //}
            }



            if (ball.transform.position.y < transform.position.y)
            {
                transform.position -= new Vector3(0, speed * Time.deltaTime, 0);

                //if (transform.position.y < startPosition.y)
                //{
                    //ball.GetComponent<BallMovement>().Player2HitUp = false;
                    //ball.GetComponent<BallMovement>().Player2HitDown = true;
                //}
            }
            //Move Down


        } 


    }
}
