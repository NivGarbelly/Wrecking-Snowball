using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowBall : MonoBehaviour
{


    [SerializeField] float radius;
    [SerializeField] float explotionForce;
    [SerializeField] float objectsAmount = 0;
    [SerializeField] Text scoreText;
    

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

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            AddScore();
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

    void AddScore()
    {
        objectsAmount++;
        scoreText.text = objectsAmount.ToString();
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    
        
    
    
}
