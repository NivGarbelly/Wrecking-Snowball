using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnowBall : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float steerForce =10;
    public float speed=1;
    public float speedChangeForce = 0.075f;
    public FloatingJoystick variableJoystick;
    public List<GameObject> collects;
    public Text steerForceText;
    public Text speedChangeText;
    public Slider steerForceSlider; 
    public Slider speedChangeSlider;
    public bool isPaused = false;
    public GameObject runOnBall;
    public GameManager gameManager;
    public ParticleSystem particleSystem;
    
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        _rigidbody = GetComponent<Rigidbody>();
        speed=1;
    }
    private void FixedUpdate()
    {
        if (isPaused==false)
        {
         _rigidbody.AddForce(Vector3.forward * speed*2);
         speed = speed + speedChangeForce;
         transform.localScale = new Vector3(speed, speed, speed)/10;
         _rigidbody.mass = speed/3;
         Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
         _rigidbody.AddForce(direction * steerForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
    public void Update()
    {
       
        speedChangeText.text = speedChangeForce.ToString();
        speedChangeForce = speedChangeSlider.value;
        steerForceText.text = steerForce.ToString();
        steerForce = steerForceSlider.value;
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
            foreach (GameObject collectibles in collects)
            {
                collectibles.gameObject.GetComponent<IStickObjects>()?.UnStick();
            }

            gameManager.SaveCollect();
            Instantiate(particleSystem, transform.position,new Quaternion(0,0,0,0));
            Destroy(runOnBall);
            Destroy(this.gameObject);
        }
        if(other.gameObject.CompareTag("Collect"))
        {
         collects.Add(other.gameObject);
        }
    }
    

    public void SpeedChangeReset()
    {
        speedChangeSlider.value = 0.075f;
    }
    public void SteerForceReset()
    {
        steerForceSlider.value =10;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IsPausedFalse()
    {
        isPaused = false;
    }
    public void IsPausedTrue()
    {
        isPaused = true;
    }
}
