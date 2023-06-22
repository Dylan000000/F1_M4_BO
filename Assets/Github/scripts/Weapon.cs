using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    public AudioSource lasereffect;

    private bool canShoot = true;
    private float shootDelay = 1.5f;
    public float time = 0f;
    public bool haveweapon;

    // Reference to the child object with the Arm_01 sprite renderer
    public GameObject arm01Object;
    // Reference to the Arm&Gun_01 sprite
    public Sprite armGunSprite;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && time >= shootDelay && haveweapon)
        {
            Shoot();
            time = 0f;
            Debug.Log("test");
        }

        if (haveweapon)
        {
            SpriteRenderer arm01Renderer = arm01Object.GetComponent<SpriteRenderer>();
            if (arm01Renderer != null)
            {
                arm01Renderer.sprite = armGunSprite;
            }
        }
    }

    void Shoot()
    {
        // Create a new bullet instance
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        lasereffect.Play();
    }
}