using UnityEngine;

public class Pickable : InteractiveP
{
    [SerializeField] private GameObject player;
    [SerializeField] private float throwForce = 8f;
    protected override void OnSelectionChanged(bool selected)
    {
        if (selected)
            PickUp();
        else
            Drop();
    }
    private void PickUp()
    {
        this.transform.SetParent(player.transform);
        rb.isKinematic = true;
        rb.useGravity = false;
        this.transform.position = player.transform.Find("Hand").position;
    }
    private void Drop()
    {
        this.transform.SetParent(null);
        rb.isKinematic = false;
        rb.useGravity = true;
    }
    public void Throw()
    {
        transform.SetParent(null);
        rb.isKinematic = false;
        rb.useGravity = true;

        Vector3 dir = Camera.main.transform.forward;
        rb.AddForce(dir * throwForce, ForceMode.Impulse);
    }
    public override bool TryInteractWith(InteractiveP other)
    {
        return false;
    }
    public override void Interact()
    {
        base.Interact();
    }
}
