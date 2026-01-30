using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopping : InteractiveP
{
    [SerializeField]
    private GameObject player;
    protected override void OnSelectionChanged(bool selected)
    {
        //animator.SetBool("Open", selected);
    }
    private void interact()
    {

    }
}
