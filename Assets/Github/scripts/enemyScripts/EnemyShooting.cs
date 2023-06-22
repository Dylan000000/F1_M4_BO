using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;
    public Animator anim;

    private float timer;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance(transform.position, player.transform.position);
        

        if(distance < 10)
        {
            
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
        }

    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        anim.SetBool("Shoot", true);
    }
}
