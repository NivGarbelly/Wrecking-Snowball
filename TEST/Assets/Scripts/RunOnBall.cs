using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunOnBall : MonoBehaviour
{
    public GameObject player;
    public float i = 25;
    void FixedUpdate()
    {
        transform.position = player.transform.position+ new Vector3(0,player.GetComponent<SnowBall>().speed/i, 0);
    }
}
