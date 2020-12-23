using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    
   
    public float radius;
    public float explotionForce;


    private void Start()
    {
       
    }
    private void Update()
    {
       
    }
    private void FixedUpdate()
    {
        transform.localScale = (transform.localScale * 1.001f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy();
        }

        if (collision.gameObject.CompareTag("Collect"))
        {

        }
    }
    public void Destroy()
    {
        Debug.Log("die");

        Collider[] stickObjects = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider objects in stickObjects)
        {
            objects.gameObject.GetComponent<StickObjects_INT>()?.UnStick();
            Rigidbody rb = objects.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explotionForce, transform.position, radius);
            }
        }
        Destroy(this.gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
        
    
    
}
