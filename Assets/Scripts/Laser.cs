using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float aliveSeconds;
    private int timeAlive = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive++;
        if (timeAlive > 60 * aliveSeconds)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.y - GameController.getEnemy().transform.position.y < 3)
        {
            GameController.getEnemy().GetComponent<EnemyController>().hp -= 3;
        }
    }
}
