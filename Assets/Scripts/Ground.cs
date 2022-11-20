using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private float speed;
    private BoxCollider2D collider2D;
    private float groundWidth;

    private void Start()
    {
      collider2D = GetComponent<BoxCollider2D>();
      groundWidth = collider2D.size.x;
    }

    private void Update()
    {
        if (GameController.İsGameOver)
        {
            return;
        }
        
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        if (transform.position.x <= -groundWidth)
        {
            transform.position = new Vector2(transform.position.x + 1.95f * groundWidth, transform.position.y);
        }
    }
}
