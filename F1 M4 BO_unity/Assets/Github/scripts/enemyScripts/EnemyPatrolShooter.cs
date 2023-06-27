using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolShooter : MonoBehaviour
{
    public float speed;
    public Transform[] patrolPoints;
    public float waitTime;
    int currentPointIndex;
    private GameObject player;
    private NavMeshAgent agent;

    bool once;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 10)
        {
            StopEnemy();
        }

        if (transform.position != patrolPoints[currentPointIndex].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        }
        else
        {
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
                transform.Rotate(0, 180, 0);
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < patrolPoints.Length)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }
        once = false;
    }
    private void StopEnemy()
    {
        agent.isStopped= true;
    }
}