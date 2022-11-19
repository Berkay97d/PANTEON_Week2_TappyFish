using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;


public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject upWall;
    [SerializeField] private GameObject downWall;

    private void OnEnable()
    {
        float ran1 = Random.Range(0, .8f);
        float ran2 = Random.Range(0, .8f);
        
        upWall.transform.position = new Vector3(upWall.transform.position.x, upWall.transform.position.y - ran1, upWall.transform.position.z);
        downWall.transform.position = new Vector3(downWall.transform.position.x, downWall.transform.position.y + ran2, downWall.transform.position.z);
    }

    private void Update()
    {
        if (GameController.İsGameOver)
        {
            return;
        }
        
        Move();
        DestroyObstacle();
    }

    private void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void DestroyObstacle()
    {
        if (transform.position.x < -7)
        {
            Destroy(gameObject);
        }
    }

    
}
