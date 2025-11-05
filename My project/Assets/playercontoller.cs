using UnityEngine;
using UnityEngine.InputSystem;

public class playercontoller : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 1f;
    public InputActionAsset inputActions;
   private Vector2 move;
    private Rigidbody2D rb;
   public GameObject canvas;
    private void Start()
    {
        moveSpeed = 0f;
    }
    public void OnMove(InputAction.CallbackContext context)
    {

        // Read the movement input
        move = context.ReadValue<Vector2>();
        Debug.Log("moveing");
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * (moveSpeed * Time.fixedDeltaTime));
    }
    public void OnCanvas()
    {
       canvas.SetActive(false);
    moveSpeed = 5f;
    }
}
