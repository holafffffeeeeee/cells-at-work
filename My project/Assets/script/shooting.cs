using UnityEngine;
using UnityEngine.InputSystem;

public class shooting : MonoBehaviour
{
    public AudioSource Audioplayer;
    public AudioClip ShootSound; 
    [Header("Shooting Settings")]
    [SerializeField] private Transform firePoint2;
    [SerializeField] private Transform firePoint3;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 20f;
    [Header("Weapon Stats")]
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float damage = 1f;
    private float nextFireTime = 0f;
    public playercontoller Player;
    public int shooterID;  // 1 or 2
   public bool ShotgunState;
    public void Fire(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (Time.time < nextFireTime) return;

        if (firePoint == null || bulletPrefab == null)
        {
            Debug.LogError("Missing firePoint or bulletPrefab!");
            return;
        }

        Audioplayer.PlayOneShot(ShootSound);

        /*Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPos.z = 0;

        Vector2 direction = (mouseWorldPos - firePoint.position).normalized;
        */
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        if(ShotgunState == true)
        {
        GameObject bullet1 = Instantiate(bulletPrefab, firePoint2.position, transform.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint3.position, transform.rotation);
            GameObject bullet3 = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            Rigidbody2D rb3 = bullet2.GetComponent<Rigidbody2D>();
            rb1.AddForce(Player.aimdir * bulletForce, ForceMode2D.Impulse);
            rb2.AddForce(Player.aimdir * bulletForce, ForceMode2D.Impulse);
            rb2.AddForce(Player.aimdir * bulletForce, ForceMode2D.Impulse);
          
           if(ShotgunState == true)
            {
                Bullet bulletScript2 = bullet.GetComponent<Bullet>();
                bulletScript2.shooterID = shooterID;
                bulletScript2.damage = damage;

            }
        }
       

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
      

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.shooterID = shooterID;
        bulletScript.damage = damage;

        if (rb != null)
        {
            rb.AddForce(Player.aimdir * bulletForce, ForceMode2D.Impulse);
        }

        nextFireTime = Time.time + fireRate;
    }

    public void SetWeaponStats(float newFireRate, float newDamage, float newBulletSpeed)
    {
        fireRate = newFireRate;
        damage = newDamage;
        bulletForce = newBulletSpeed;
    }
}