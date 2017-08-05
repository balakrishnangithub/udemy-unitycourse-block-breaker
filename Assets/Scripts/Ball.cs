using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;
    private Rigidbody2D rb;
    private AudioSource hitAudio;

    // Use this for initialization
    void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        rb = this.GetComponent("Rigidbody2D") as Rigidbody2D;
        hitAudio = this.GetComponent("AudioSource") as AudioSource;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                rb.velocity = new Vector2(2f, 10f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            rb.velocity += new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.3f));
            hitAudio.Play();
        }
    }
}