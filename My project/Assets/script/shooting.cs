using UnityEngine;
using UnityEngine.InputSystem;

public class shooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private Transform firePoint2;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 20f;

    public int shooterID;  // 1 or 2

    public void Fire(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (firePoint == null || bulletPrefab == null)
        {
            Debug.LogError("Missing firePoint or bulletPrefab!");
            return;
        }

        // get mouse pos
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPos.z = 0;

        Vector2 direction = (mouseWorldPos - firePoint.position).normalized;

        // spawn bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // assign shooter ID to bullet
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.shooterID = shooterID;

        // add force
        if (rb != null)
        {
            rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
        }
    }
}