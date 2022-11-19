using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Canvas beforeGame;
    [SerializeField] private Canvas inGame;
    [SerializeField] private Canvas endGame;

    [SerializeField] private TMP_Text inGameScoreText;
    [SerializeField] private TMP_Text endGameScoreText;
    [SerializeField] private TMP_Text highScoreText;
    public static int score = 0;
    private int highscore = 0;
    
    
    
    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if(Time.timeScale == 0 )
        {
            if (Input.GetMouseButtonDown(0))
            {
                beforeGame.gameObject.SetActive(false);
                inGame.gameObject.SetActive(true);
                Time.timeScale = 1;
            }
        }
        else
        {
            HandleUI();
        }
        
    }

    private void HandleUI()
    {
        if (GameController.İsGameOver)
        {
            inGame.gameObject.SetActive(false);
            endGame.gameObject.SetActive(true);
        }
        else
        {
            inGame.gameObject.SetActive(true);
            endGame.gameObject.SetActive(false);
        }

        inGameScoreText.text = score.ToString();
        endGameScoreText.text = score.ToString();

        if (score > highscore)
        {
            highscore = score;
        }

        highScoreText.text = highscore.ToString();
    }

    public void RestartGame()
    {
        beforeGame.gameObject.SetActive(true);
        endGame.gameObject.SetActive(false);
        score = 0;
        Time.timeScale = 0;
        GameController.İsGameOver = false;
        var obs = FindObjectsOfType<Obstacle>();

        foreach (var VARIABLE in obs)
        {
            Destroy(VARIABLE.gameObject);
        }
    }
    
    
}
