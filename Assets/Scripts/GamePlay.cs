using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public Button PVPButton;
    public Button PVEButton;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        PVPButton = GetComponent<Button>();
        PVPButton.onClick.AddListener(PVP);

        PVEButton = GetComponent<Button>();
        PVEButton.onClick.AddListener(PVE);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void PVP()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.PVPStartGame();
    }

    void PVE()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.PVEStartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
