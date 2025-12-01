using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class playercontoller : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 1f;
    public InputActionAsset inputActions;
    public Vector2 move;
    private Rigidbody2D rb;
    public playerManager PlayerManager;
    public Vector2 aimdir;
    public Vector2 mousePOS;
    public bool useMouse;
    public bool TurnOnCanvas = true;

  public  GameObject pannel;
    private void Start()
    {
      //Time.timeScale = 0;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("Spelare " + gameObject.name + " tries to move.");
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
     // mousePOS = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * (moveSpeed * Time.fixedDeltaTime));
        if (useMouse == true)
        {
           aimdir = mousePOS - rb.position;
        }
        aimdir.Normalize();
        transform.up = aimdir;
        Debug.DrawRay(transform.position, aimdir * 5f);
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
    }

    public void onlookdirections(InputAction.CallbackContext context)
    {
      useMouse = false;
     
        aimdir = context.ReadValue<Vector2>();
   
    }
    public void onUpdatelookTarget(InputAction.CallbackContext context)
    {
        useMouse = true;

        mousePOS = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());

    }
     public void canvas()
    {
        pannel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
