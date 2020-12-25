using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToSnowball : MonoBehaviour, StickObjects_INT
{

    private FixedJoint fixJoint;
    private GameObject snowBall;
    private Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        fixJoint = GetComponent<FixedJoint>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        snowBall = other.gameObject;

        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Stick", 0.25f);

        }

    }

    private void Stick()
    {
        fixJoint.connectedBody = snowBall.GetComponent<Rigidbody>();
    }

    public void UnStick()
    {
        Debug.Log("work");
        rb.mass = 1f;
        fixJoint.breakForce = 10f;
        fixJoint.breakTorque = 10f;
        var col = GetComponent<Collider>();
        col.isTrigger = false;
        
    }
}