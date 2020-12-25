using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public float radius;
    public float explotionForce;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.localScale = (transform.localScale * 1.003f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.localScale = (transform.localScale * 0.90f);
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
    void OnDrawGizmosSelected()z
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
