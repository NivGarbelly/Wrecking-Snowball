using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    private GameObject thisOBJ;
    private GameObject otherOBJ;

    public StickToSnowball stickObjectScript;
    public float radius; 


    private void Start()
    {
       
    }
    private void Update()
    {
        // transform.localScale = transform.localScale * 1.5f
    }
    private void FixedUpdate()
    {
            transform.localScale = (transform.localScale * 1.001f);
    }
    private void OnTriggerEnter(Collider other)
    {
        otherOBJ = other.gameObject;
        thisOBJ = this.gameObject;
        Invoke("Stick",0.25f);
    }

    public void Destroy()
    {
        Debug.Log("die");

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        stickObjectScript.UnStick();
        Destroy(this.gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
        
    
    private void Stick()
    {
       // otherOBJ.transform.SetParent(thisOBJ.transform,true);
    }
}
