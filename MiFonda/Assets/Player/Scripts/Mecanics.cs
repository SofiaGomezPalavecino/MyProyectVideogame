using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Mecanics : MonoBehaviour
{
    public event Action<InteractiveP, bool> SelectionChanged;

    [SerializeField] private InputActionReference select;
    [SerializeField] private InputActionReference mouse;
    [SerializeField] private float rayDistance = 3f;
    private InteractiveP selectedInteractive;

    private InteractiveP currentInteractive;

    void Update()
    {
        UpdateRaycast();

        if (select.action.WasPressedThisFrame())
        {
            HandleSelectionInput();
        }
        if (mouse.action.IsInProgress())
        {
            HandleThrowInput();
        }
    }
    private void HandleSelectionInput()
    {
        if (selectedInteractive != null && currentInteractive != null)
        {
            selectedInteractive.TryInteractWith(currentInteractive);
            return;
        }

        if (selectedInteractive == null && currentInteractive != null)
        {
            selectedInteractive = currentInteractive;
            SelectionChanged?.Invoke(selectedInteractive, true);
            return;
        }

        if (selectedInteractive != null)
        {
            SelectionChanged?.Invoke(selectedInteractive, false);
            selectedInteractive = null;
        }
    }

    private void HandleThrowInput()
    {
        if (selectedInteractive == null)
            return;

        if (selectedInteractive is Pickable pickable)
        {
            selectedInteractive.SetSelected(false);
            pickable.Throw();
            selectedInteractive = null;
        }
    }

    private void UpdateRaycast()
    {
        Camera cam = Camera.main;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            var interactive = hit.collider.GetComponent<InteractiveP>();

            if (interactive != null)
            {
                currentInteractive = interactive;
                interactive.Interact();
            }
        }
        else
        {
            currentInteractive = null;
        }
    }

}
