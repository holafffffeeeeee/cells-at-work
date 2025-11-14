using UnityEngine;
using UnityEngine.InputSystem;

public class player2contolls : MonoBehaviour
{
    public Vector2 move;
    [SerializeField] public float moveSpeed = 1f;
    public InputActionAsset inputActions;
    private Rigidbody2D rb;

    public Vector2 mousePOS;
    public void OnMove(InputAction.CallbackContext context)
    {

        // Read the movement input
   move = context.ReadValue<Vector2>();
        Debug.Log("moveing");
    }
    private void Update()
    {
        mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + move * (moveSpeed * Time.fixedDeltaTime));
        Vector2 lookDir = mousePOS - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

}
