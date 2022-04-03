using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBetweenObstacleDetector : MonoBehaviour
{
    private Collider2D colliderDetector;
    public int countObstacles = 0;

    void Start()
    {
        colliderDetector = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("WallTile"))
            countObstacles++;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("WallTile"))
            countObstacles--;
    }
}
