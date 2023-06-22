using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;
    

    private void Start()
    {
       
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > minimumDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
           
        }
        else
        {
            //attack code
        }
    }

}
