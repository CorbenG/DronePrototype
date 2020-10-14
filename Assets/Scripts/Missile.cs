using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float rotateAmount;
    public float RotateSpeedInDeg;
    public float ForwardSpeed;

    public Vector2 initSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 mouse_pos = Input.mousePosition;
        Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        float angle = (Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vectorToEnemy = (Vector2)transform.position - (Vector2)GameController.getEnemy().transform.position;

        vectorToEnemy.Normalize();

        float crossProduct = Vector3.Cross(vectorToEnemy, transform.up).z;

        if (crossProduct > 0)
        {
            rotateAmount = RotateSpeedInDeg;
        }
        else if (crossProduct < 0)
        {
            rotateAmount = -RotateSpeedInDeg;
        }

        transform.Rotate(new Vector3(0, 0, rotateAmount));
        transform.position = new Vector3(transform.position.x + (transform.up.x * ForwardSpeed + initSpeed.x) * Time.deltaTime, transform.position.y + (transform.up.y * ForwardSpeed + initSpeed.y) * Time.deltaTime);

        if (Mathf.Sqrt(Mathf.Pow(transform.position.x - GameController.getEnemy().transform.position.x, 2) + Mathf.Pow(transform.position.y - GameController.getEnemy().transform.position.y, 2)) < 1)
        {
            Destroy(this.gameObject);
            GameController.getEnemy().GetComponent<EnemyController>().hp -= 25; 
        }
    }
}
