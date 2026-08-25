using UnityEngine;
using UnityEngine.Audio;

public class playerShoots : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public GameObject secondoBullet;

    public float canShootTimer;
    public float shootTimer2;
    public bool canShoot;
    public bool canShootSecondo;

    public AudioSource shootSfx1;
    public AudioSource shootSfx2;

    private void Awake()
    {
        canShoot = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && canShoot == true)
        {
            Shoot();
            canShoot = false;
        }

        if(canShoot == false)
        {
            canShootTimer += Time.deltaTime;
            if(canShootTimer >= 0.25f)
            {
                canShoot = true;
                canShootTimer = 0;
            }
        }

        if(Input.GetMouseButton(1) && canShootSecondo == true)
        {
            Shoot2();
            canShootSecondo = false;
        }

        if(canShootSecondo == false)
        {
            shootTimer2 += Time.deltaTime;
            if(shootTimer2 >= 0.8f)
            {
                canShootSecondo = true;
                shootTimer2 = 0;
            }
        }

    }
    private void Shoot()
    {
        Rigidbody rbBullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity).GetComponent<Rigidbody>();
        rbBullet.linearVelocity = bulletSpawn.forward * bulletSpeed;
        Destroy(rbBullet.gameObject, 2f);
        shootSfx1.Play();
    }

    private void Shoot2()
    {
        Rigidbody rbBullet2 = Instantiate(secondoBullet, bulletSpawn.position, Quaternion.identity ).GetComponent<Rigidbody>();
        rbBullet2.linearVelocity = bulletSpawn.forward * bulletSpeed;
        Destroy(rbBullet2.gameObject, 2f);
        shootSfx2.Play();
    }
}
