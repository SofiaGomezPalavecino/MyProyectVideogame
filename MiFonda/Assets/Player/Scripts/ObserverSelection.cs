using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObserverSelection : MonoBehaviour
{
    public Mecanics mecanics;
    public InteractiveP interactive;

    void Start()
    {
        if (mecanics != null)
        {
            // Suscribirse al evento
            mecanics.SelectionChanged += HandleScoreChanged;

            HandleScoreChanged(mecanics.optionValue);
        }
    }
    void HandleScoreChanged(int newValue)
    {
        if (interactive != null)
        {
            interactive.NotifyValueChanged(newValue);
        }
    }

    void OnDestroy()
    {
        // Asegurarse de desuscribirse para evitar fugas de memoria
        if (mecanics != null)
        {
            mecanics.SelectionChanged -= HandleScoreChanged;
        }
    }
}