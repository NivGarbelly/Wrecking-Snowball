using System.Collections;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float steerForce =2;
    public float speed=1;
    public float speedChangeForce = 0.01f;
    public FloatingJoystick variableJoystick;
    public GameObject[] collect;
    public int collectedObject = 0;
    public GameManager gameManager;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        speed=1;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(Vector3.forward * speed*2);
        speed = speed + speedChangeForce;
        transform.localScale = new Vector3(speed, speed, speed)/10;
        _rigidbody.mass = speed/3;
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        _rigidbody.AddForce(direction * steerForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            speed = speed * 0.9f;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            DestroyFun();
        }

        if (other.gameObject.CompareTag("Collect"))
        {

            collectedObject++;
            gameManager.finishObjectAmount = collectedObject;
        }
    }

    

    private void DestroyFun()
    {
        collect = GameObject.FindGameObjectsWithTag("Collect");
        foreach (var Obj in collect)
        {
            Obj.gameObject.GetComponent<StickObjects_INT>()?.UnStick();
        }
        Destroy(this.gameObject);
    }
}
