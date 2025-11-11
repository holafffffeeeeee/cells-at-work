using UnityEngine;
using UnityEngine.InputSystem;

public class shooting : MonoBehaviour
{
    [Header("Shooting Settings")]
     [SerializeField] private Transform firePoint2;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 20f;

   

   

    public void Fire(InputAction.CallbackContext context)
    {
        // Only spawn bullet once per click
        if (!context.performed) return;

        if (firePoint == null || bulletPrefab == null)
        {
            Debug.LogError("Missing firePoint or bulletPrefab!");
            return;
        }

        // Get mouse position in world space
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPos.z = 0;


        // Calculate direction
        Vector2 direction = (mouseWorldPos - firePoint.position).normalized;
      //  Vector2 direction2 = (mouseWorldPos - firePoint2.position).normalized;
        // Spawn and shoot bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
       // GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

       // Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
           // rb2.AddForce(direction * bulletForce, ForceMode2D.Impulse);
        }
    }
    }