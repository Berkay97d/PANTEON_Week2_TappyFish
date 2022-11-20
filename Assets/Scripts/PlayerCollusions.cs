using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerCollusions : MonoBehaviour
{
    private PlayerController playerController;
    private bool isSoundPlayed = false;
    
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            if (!isSoundPlayed)
            {
                playerController.PlayHitSound();
                GameController.İsGameOver = true;
            }

            isSoundPlayed = true;
            return;
        }
        
        playerController.PlayPointSound();
        UIController.score++;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            if (!isSoundPlayed)
            {
                playerController.PlayHitSound();
                isSoundPlayed = true;
            }
            GameController.İsGameOver = true;
        }
    }
}
