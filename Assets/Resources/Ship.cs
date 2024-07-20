using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject propulsionOff;
    public GameObject propulsionOn;
    public float engineThrustFactor = 5;
    public float turnSpeed = 90.0f;
    public float fireInterval = 1;
    public float bulletVelocity = 10;
    private float nextFireTime = 0;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Accelerate the ship in the direction it is currently facing
        if (Input.GetKey(KeyCode.W))
        {
            propulsionOff.SetActive(false);
            propulsionOn.SetActive(true);
            rb.AddForce(transform.up * engineThrustFactor, ForceMode.Impulse);
        }
        else
        {
            propulsionOff.SetActive(true);
            propulsionOn.SetActive(false);
        }

        // Rotate the ship left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
        }

        // Rotate the ship right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.J) && Time.realtimeSinceStartup > nextFireTime)
        {
            GameObject blt = Instantiate(Game.prefabShipBullet, transform.position + 1.5f * transform.up, transform.rotation);
            Rigidbody brb = blt.GetComponent<Rigidbody>();
            brb.linearVelocity = transform.up * bulletVelocity;
            nextFireTime = Time.realtimeSinceStartup + fireInterval;
        }

        transform.position = Game.GameAreaRoll(transform.position);
    }
}
