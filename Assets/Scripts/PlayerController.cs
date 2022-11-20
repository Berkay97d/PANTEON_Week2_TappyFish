using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using DefaultNamespace;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private int angle;
    [SerializeField] private int maxAngle;
    [SerializeField] private int minAngle;
    [SerializeField] private AudioSource swim;
    [SerializeField] private  AudioSource hit;
    [SerializeField] private  AudioSource point;
    private Rigidbody2D rb;
    private Vector3 startPos;
    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;

    }

    public void RestartGame()
    {
        transform.position = startPos;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
    
    private void Update()
    {
        if (GameController.İsGameOver)
        {
            return;
        }
        
        Jump();
        Rotate();
    }

    private void Jump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swim.Play();
            rb.velocity = Vector2.zero;;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
        }
    }

    private void Rotate()
    {
        if (rb.velocity.y > 0 && angle <= maxAngle)
        {
            angle += 4;
        }
        else if (rb.velocity.y < -3f && angle>minAngle)
        {
            angle -= 2;
        }
        
        transform.rotation = Quaternion.Euler(0,0,angle);
    }

    public void PlayPointSound()
    {
        point.Play();
    }
    
    public void PlayHitSound()
    {
        hit.Play();
    }
}
