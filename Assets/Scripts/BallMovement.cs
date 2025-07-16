//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using System.Runtime.CompilerServices;
//using JetBrains.Annotations;
using TMPro;
//using Unity.VisualScripting;
//using UnityEditor.Callbacks;
//using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    private Rigidbody rb;

    public GameManager gameManager;
    public GameObject Player2PVEPaddle;

    
    public float ballSpeed = 5f;
    private float Spike = 10f;
    public float SpikePVE = 10f;
    private float startSpeed = 10f;
    public bool Active = false;

    //private float bounceStrength = 5f;
    private Vector3 previousVelocity;
    private bool Player1Hit;
    private bool Player1HitUp;
    private bool Player1HitDown;
    private bool Player2Hit;
    public bool Player2HitUp;
    public bool Player2HitDown;
    public bool LowerWallHit;
    public bool TopWallHit;
    private Vector3 startPosition;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startSpeed = ballSpeed;
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        Player2Hit = true;
    }




    // Update is called once per frame
    void Update()
    {
        if (Player2Hit == true)
        {
            transform.Translate(Vector3.left * ballSpeed * Time.deltaTime);
        }

        if (Player1Hit == true)
        {
            transform.Translate(Vector3.right * ballSpeed * Time.deltaTime);
        }

        if (Player1HitDown == true)
        {
            transform.position -= new Vector3(0, ballSpeed * Time.deltaTime, 0);
        }

        if (Player1HitUp == true)
        {
            transform.position += new Vector3(0, ballSpeed * Time.deltaTime, 0);
        }

        if (Player2HitDown == true)
        {
            transform.position -= new Vector3(0, ballSpeed * Time.deltaTime, 0);
        }

        if (Player2HitUp == true)
        {
            transform.position += new Vector3(0, ballSpeed * Time.deltaTime, 0);
        }

        if (LowerWallHit == true)
        {

            transform.position += new Vector3(0, ballSpeed * Time.deltaTime, 0);
            previousVelocity = rb.velocity;
            //transform.Translate(Vector3.up * ballSpeed * Time.deltaTime);
        }

        if (TopWallHit == true)
        {

            transform.position -= new Vector3(0, ballSpeed * Time.deltaTime, 0);
            previousVelocity = rb.velocity;
            //transform.Translate(Vector3.down * ballSpeed * Time.deltaTime);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        previousVelocity = rb.velocity;

        if (collision.gameObject.CompareTag("Player1"))
        {
            previousVelocity = rb.velocity;
            Player1Hit = true;
            Player2Hit = false;
            ballSpeed += 0.2f;

            if (Input.GetKey(KeyCode.S))
            {
                Player1HitDown = true;
                Player1HitUp = false;
                TopWallHit = false;
                LowerWallHit = false;

            }

            if (Input.GetKey(KeyCode.W))
            {
                Player1HitUp = true;
                Player1HitDown = false;
                TopWallHit = false;
                LowerWallHit = false;
            }

            if (Input.GetKey(KeyCode.D)&& !Active)
            {
                //Active = true;
                Player1Hit = true;
                Player1HitDown = false;
                Player1HitUp = false;
                TopWallHit = false;
                LowerWallHit = false;
                ballSpeed += Spike;        
                //StartCoroutine (ActiveFor5Seconds());
            }

            //IEnumerator ActiveFor5Seconds()
            //{
                //yield return new WaitForSeconds(5f);
       
                //Active = false;
            //}
        }

        else if (collision.gameObject.CompareTag("Player2"))
        {

            previousVelocity = rb.velocity;
            Player2Hit = true;
            Player1Hit = false;
            TopWallHit = false;
            LowerWallHit = false;
            ballSpeed += 0.2f;



            if (Player2PVEPaddle.transform.position.y < transform.position.y)
            {
                previousVelocity = rb.velocity;
                Player2HitUp = true;
                Player2HitDown = false;
                TopWallHit = false;
                LowerWallHit = false;
            }

            if (Player2PVEPaddle.transform.position.y > transform.position.y)
            {
                previousVelocity = rb.velocity;
                Player2HitDown = true;
                Player2HitUp = false;
                TopWallHit = false;
                LowerWallHit = false;
            }

            else if (gameManager.randomNumber == 2)
            {
                previousVelocity = rb.velocity;
                Player2Hit = true;
                Player1Hit = false;
                TopWallHit = false;
                LowerWallHit = false;
                Player2HitDown = false;
                Player2HitUp = false;
                ballSpeed += Spike;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                Player2HitDown = true;
                Player2HitUp = false;
                TopWallHit = false;
                LowerWallHit = false;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                Player2HitUp = true;
                Player2HitDown = false;
                TopWallHit = false;
                LowerWallHit = false;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Player2Hit = true;
                Player2HitDown = false;
                Player2HitUp = false;
                TopWallHit = false;
                LowerWallHit = false;
                ballSpeed += Spike;
            }

        }

        if (collision.gameObject.CompareTag("BottomWall"))
        {
            previousVelocity = rb.velocity;
            LowerWallHit = true;
            TopWallHit = false;
            Player1HitDown = false;
            Player2HitDown = false;
            ballSpeed += 0.5f;
        }

        if (collision.gameObject.CompareTag("TopWall"))
        {
            previousVelocity = rb.velocity;
            TopWallHit = true;
            LowerWallHit = false;
            Player1HitUp = false;
            Player2HitUp = false;
            ballSpeed += 0.5f;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            //gameOverText.gameObject.SetActive(true);
            //restartButton.gameObject.SetActive(true);
            if (collision.gameObject.name == "LeftWall")
            {
                gameManager.UpdatePlayer2Score(1);
            }

            else if (collision.gameObject.name == "RightWall")
            {
                gameManager.UpdatePlayer1Score(1);
            }

            transform.position = startPosition;
            ballSpeed = startSpeed;
        }
    }


}
