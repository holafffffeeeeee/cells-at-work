using UnityEngine;
using UnityEngine.InputSystem;

public class shooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private Transform firePoint2;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 20f;
    [Header("Weapon Stats")]
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float damage = 1f;
    private float nextFireTime = 0f;

    public int shooterID;  // 1 or 2
    public void Fire(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (Time.time < nextFireTime) return;

        if (firePoint == null || bulletPrefab == null)
        {
            Debug.LogError("Missing firePoint or bulletPrefab!");
            return;
        }

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPos.z = 0;

        Vector2 direction = (mouseWorldPos - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.shooterID = shooterID;
        bulletScript.damage = damage;

        if (rb != null)
        {
            rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
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