using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NotifyValueChanged(int newValue)
    {
        // Manejar la notificación del cambio de valor
        Debug.Log("El valor ha cambiado a: " + newValue);

        if (newValue == 1)
        {
            Debug.Log($"Valor: {newValue}");
        }
        else if (newValue == 2)
        {
            Debug.Log($"Abrir UI: {newValue}");
        }

    }
}
