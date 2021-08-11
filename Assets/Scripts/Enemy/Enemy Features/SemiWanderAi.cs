using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiWanderAi : MonoBehaviour
{
    public float speed;
    public float range;
    public float maxDistance;
    private Transform Wander;

    Vector2 wayPoint;
    private void Start()
    {
        SetNewPos();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewPos();
        }

    }
    void SetNewPos()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), 0);
    }
}
