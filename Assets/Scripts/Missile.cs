using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float rotateAmount;
    public float RotateSpeedInDeg;
    public float ForwardSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
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
        transform.position = new Vector3(transform.position.x + transform.up.x * ForwardSpeed * Time.deltaTime, transform.position.y + transform.up.y * ForwardSpeed * Time.deltaTime);

        if (Mathf.Sqrt(Mathf.Pow(transform.position.x - GameController.getEnemy().transform.position.x, 2) + Mathf.Pow(transform.position.x - GameController.getEnemy().transform.position.y, 2)) < 1)
        {
            Destroy(this.gameObject);
            GameController.getEnemy().GetComponent<EnemyController>().hp -= 25; 
        }
    }
}
