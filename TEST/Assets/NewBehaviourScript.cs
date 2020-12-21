using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject thisOBJ;
    private GameObject otherOBJ;

    private void Update()
    {
        transform.localScale = transform.localScale * 1.01f;
    }

    private void OnTriggerEnter(Collider other)
    {
        otherOBJ = other.gameObject;
        thisOBJ = this.gameObject;
        Invoke("Stick",0.25f);
    }

    private void Stick()
    {
        otherOBJ.transform.SetParent(thisOBJ.transform,true);
    }
}
