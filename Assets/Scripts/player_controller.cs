using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float max_horizontal_speed = 30.0f;
    public float max_thrust = 20.0f;
    public Vector2 speed;
    float v_thrust;
    float h_thrust;
    public float h_limiter = 0.25f;
    public float v_limiter = 0.25f;
    public Rigidbody2D rb;
    public float speedBoost = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        v_thrust = Mathf.Lerp(v_thrust, Input.GetAxis("Vertical") * max_thrust - speed.y*v_limiter, Time.deltaTime * 30);
        h_thrust = Mathf.Lerp(h_thrust, Input.GetAxis("Horizontal") * max_thrust - speed.x*h_limiter, Time.deltaTime * 30);

        //speed.x += h_thrust * Time.deltaTime;
        //speed.y += v_thrust * Time.deltaTime;

        rb.velocity = new Vector2(h_thrust + speedBoost, v_thrust);
        speedBoost--;
        if(speedBoost < 0)
        {
            speedBoost = 0;
        }

        //transform.position += new Vector3(speed.x, speed.y, 0) * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, 0, (h_thrust * -1.0f)/max_thrust*30);

        if(transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
            speed.y = 0;
        }
        if (transform.position.y < -5)
        {
            transform.position = new Vector3(transform.position.x, -5, transform.position.z);
            speed.y = 0;
        }

        if (transform.position.x < -8)
        {
            transform.position = new Vector3(-8, transform.position.y, transform.position.z);
            speed.x = 0;
        }

        GetComponent<AudioSource>().pitch = Mathf.Pow(1.1f, Mathf.Abs(h_thrust) * 0.2f + (v_thrust) * 0.5f);
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
