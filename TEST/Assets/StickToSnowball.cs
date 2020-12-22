using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToSnowball : MonoBehaviour
{

    private FixedJoint fixJoint;
    private GameObject snowBall;


    // Start is called before the first frame update
    void Start()
    {
        fixJoint = GetComponent<FixedJoint>();
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
        fixJoint.breakForce = 1f;
        fixJoint.breakTorque = 1f;
        fixJoint.enableCollision = true;
        var col = GetComponent<Collider>();
        col.isTrigger = false;
    }
}