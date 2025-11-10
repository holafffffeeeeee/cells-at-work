using UnityEngine;
using UnityEngine.InputSystem;

public class playercontoller : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 1f;
    public InputActionAsset inputActions;
   private Vector2 move;
    private Rigidbody2D rb;
   public GameObject canvas;
    public Camera cam;
    public Vector2 mousePOS;
    private void Start()
    {
      Time.timeScale = 0;
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
    private void Update()
    {
       mousePOS = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * (moveSpeed * Time.fixedDeltaTime));
        Vector2 lookDir  = mousePOS - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    public void OnCanvas()
    {
       canvas.SetActive(false);
    Time.timeScale = 1;
    }
}
