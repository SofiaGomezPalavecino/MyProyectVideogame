using UnityEngine;

public abstract class InteractiveP : MonoBehaviour
{
    protected Rigidbody rb;

    public bool IsSelected { get; private set; }

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetSelected(bool selected)
    {
        if (IsSelected == selected) return;

        IsSelected = selected;
        OnSelectionChanged(selected);
    }

    // Cada hijo decide qué hacer con el cambio
    protected abstract void OnSelectionChanged(bool selected);

    public virtual bool TryInteractWith(InteractiveP other)
    {
        return false;
    }

    // Para hover / feedback (raycast)
    public virtual void Interact()
    {

    }
}
