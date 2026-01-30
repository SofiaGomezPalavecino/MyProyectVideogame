using UnityEngine;

public class Door : InteractiveP
{
    [SerializeField] private Animator animator;

    protected override void OnSelectionChanged(bool selected)
    {
        //animator.SetBool("Open", selected);
    }

    public override void Interact()
    {
        // Hover, UI, sonido, etc.
    }
}