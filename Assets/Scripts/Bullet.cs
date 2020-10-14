using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Vector2 initVel;
    public float aliveSeconds;
    private int timeAlive = 0;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 mouse_pos = Input.mousePosition;
        Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        float angle = (Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (transform.right.x * speed + initVel.x) * Time.deltaTime, transform.position.y + (transform.right.y * speed) * Time.deltaTime, transform.position.z);
        timeAlive++;
        if(timeAlive > 60 * aliveSeconds)
        {
            Destroy(this.gameObject);
        }

        if (Mathf.Sqrt(Mathf.Pow(transform.position.x - GameController.getEnemy().transform.position.x, 2) + Mathf.Pow(transform.position.y - GameController.getEnemy().transform.position.y, 2)) < 1)
        {
            Destroy(this.gameObject);
            GameController.getEnemy().GetComponent<EnemyController>().hp -= 1;
        }

    }
}
