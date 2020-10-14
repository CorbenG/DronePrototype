using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float max_horizontal_speed = 30.0f;
    public float max_thrust = 20.0f;
    Vector2 speed;
    float v_thrust;
    float h_thrust;
    public float h_limiter = 0.25f;
    public float v_limiter = 0.25f;

    private void Start()
    {
    }
    void Update()
    {
        v_thrust = Mathf.Lerp(v_thrust, Input.GetAxis("Vertical") * max_thrust - speed.y*v_limiter, Time.deltaTime * 30);
        h_thrust = Mathf.Lerp(h_thrust, Input.GetAxis("Horizontal") * max_thrust - speed.x*h_limiter, Time.deltaTime * 30);
        speed.y += v_thrust * Time.deltaTime;

        speed.x += h_thrust * Time.deltaTime;
        
        transform.position += new Vector3(speed.x, speed.y, 0) * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, 0, (h_thrust * -1.0f)/max_thrust*30);
    }
}
