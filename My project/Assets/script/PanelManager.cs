
using UnityEngine;
using UnityEngine.InputSystem;

public class PanelManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject panel;

    private InputSystem_Actions inputActions;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();

        if (panel != null)
        {
            panel.SetActive(true);
        }
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Interact.performed += OnOpenPanel;
    }

 public void OnDisable()
    {
        inputActions.Player.Interact.performed -= OnOpenPanel;
        inputActions.Player.Disable();
    }

   public void OnOpenPanel(InputAction.CallbackContext context)
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}


