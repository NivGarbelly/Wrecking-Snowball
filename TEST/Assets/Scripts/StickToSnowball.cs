using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToSnowball : MonoBehaviour, StickObjects_INT
{

    private FixedJoint fixJoint;
    private Rigidbody rb;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    
    void Start()
    {
        fixJoint = GetComponent<FixedJoint>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fixJoint.connectedBody = other.gameObject.GetComponent<Rigidbody>();
        }
        if (other.gameObject.name=="X2")
        {
            gameManager.X2();
        }
        if (other.gameObject.name=="X3")
        {
            gameManager.X3();
        }
        if (other.gameObject.name=="X4")
        {
            gameManager.X4();
        }
        if (other.gameObject.name=="X5")
        {
            gameManager.X5();
        }
        if (other.gameObject.name=="X6")
        {
            gameManager.X6();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UnStick();
        }
    }

    public void UnStick()
    {
        rb.mass = 1f;
        fixJoint.breakForce = 10f;
        fixJoint.breakTorque = 10f;
        var col = GetComponent<Collider>();
        col.isTrigger = false;
    }
}