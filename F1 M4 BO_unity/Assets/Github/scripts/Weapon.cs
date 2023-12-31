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
    private float time = 0f;
    private bool haveweapon;
    public GameObject laser;

    // Reference to the child object with the Arm_01 sprite renderer
    public GameObject arm01Object;
    // Reference to the Arm&Gun_01 sprite
    public Sprite armGunSprite;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("weapon"))
        {
            haveweapon = true;
            Destroy(other.gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && time >= shootDelay && haveweapon)
        {
            Shoot();
            time = 0.2f;
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

    IEnumerator ActivateAndDeactivateLaser(float duration)
    {
        laser.SetActive(true);
        yield return new WaitForSeconds(duration);
        laser.SetActive(false);
    }

    void Shoot()
    {
        lasereffect.Play();
        StartCoroutine(ActivateAndDeactivateLaser(0.5f));
    }
}