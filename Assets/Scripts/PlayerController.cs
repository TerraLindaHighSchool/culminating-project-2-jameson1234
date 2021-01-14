using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed;
    private float horizontalInput;
    private float forwardInput;
    private float powerupStrength = 15.0f;
    public ParticleSystem explosionParticle;
    private SpawnManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // Moves the car forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Debug.Log("Vehicle collided with " + collision.gameObject + " with powerup set to ");
            enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

        }
    }
}
