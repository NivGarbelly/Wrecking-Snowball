using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public float radius;
    public float explotionForce;
    private Rigidbody _rigidbody;
    public float steerForce =2;
    public float speed=1;
    public float speedChangeForce = 0.01f;
    public FloatingJoystick variableJoystick;

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
        _rigidbody.mass = speed;
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        _rigidbody.AddForce(direction * steerForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            
            Destroy(collision.gameObject);
        }
    }
    public void Destroy()
    {
        Debug.Log("die");

        Collider[] stickObjects = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider objects in stickObjects)
        {
            objects.gameObject.GetComponent<StickObjects_INT>()?.UnStick();
            if (_rigidbody != null)
            {
                _rigidbody.AddExplosionForce(explotionForce, transform.position, radius);
            }
        }
        Destroy(this.gameObject);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
