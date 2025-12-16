using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mecanics : MonoBehaviour
{
    public event Action<int> SelectionChanged;
    [SerializeField] private InputActionReference select;
    [SerializeField] private int option;

    public int optionValue
    {
        get { return option; } 
        set
            {
            if (option != value) // Solo notificar si el valor cambia
            {
                option = value;
                SelectionChanged?.Invoke(option); // Notifica a los observadores
            }
        } 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (select.action.IsPressed())
        {
            IsGrounded();
        }
        else
        {
            option = 0;
        }
    }
    private void IsGrounded()
    {
        // Obtiene la posición de la cámara
        Camera camera = Camera.main;

        // Lanza un rayo desde la cámara en la dirección en la que está mirando
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Realiza el Raycast
        if (Physics.Raycast(ray, out hit))
        {
            isAnObject(hit.collider.gameObject.tag);
        }
        else
        {
            option = 0;
        }
    }
    private void isAnObject(string tag)
    {
        switch (tag)
        {
            case "Untagged":
                option = 0;
                break;
            case "Collectable":
                option = 1;
                break;
            case "Selection":
                option = 2;
                break;
        }
    }
}
