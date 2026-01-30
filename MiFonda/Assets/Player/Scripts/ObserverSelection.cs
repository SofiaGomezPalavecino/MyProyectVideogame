using UnityEngine;

public class ObserverSelection : MonoBehaviour
{
    public Mecanics mecanics;

    private void Start()
    {
        mecanics.SelectionChanged += HandleSelectionChanged;
    }

    private void HandleSelectionChanged(InteractiveP interactive, bool selected)
    {
        if (interactive != null)
        {
            interactive.SetSelected(selected);
        }
    }

    private void OnDestroy()
    {
        mecanics.SelectionChanged -= HandleSelectionChanged;
    }
}
