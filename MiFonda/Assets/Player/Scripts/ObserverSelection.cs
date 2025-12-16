using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObserverSelection : MonoBehaviour
{
    public Mecanics mecanics;
    public Shopping shoppingReceiver;
    public UIScript uiScriptResiver;

    void Start()
    {
        if (mecanics != null)
        {
            //mecanics.OnScoreChanged += HandleScoreChanged;
        }
    }

    void HandleScoreChanged(int newValue)
    {
        if (shoppingReceiver != null)
        {
            shoppingReceiver.NotifyValueChanged(newValue);
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