using UnityEngine;
using UnityEngine.InputSystem;

public class shooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce = 20f;

    private InputSystem_Actions inputActions;

    private void Awake()
    {
        // Initialize your input system actions
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        // Enable the action map and register callback
        inputActions.Player1.Attack.performed += Fire;
        inputActions.Player1.Enable();
    }

    private void OnDisable()
    {
        // Clean up when disabled
        inputActions.Player1.Attack.performed -= Fire;
        inputActions.Player1.Disable();
    }

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

        // Spawn and shoot bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
        }
    }
    }