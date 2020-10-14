using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Collider2D col;

    public AudioClip upSound;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Sqrt(Mathf.Pow(transform.position.x - GameController.getPlayer().transform.position.x, 2) + Mathf.Pow(transform.position.y - GameController.getPlayer().transform.position.y, 2)) < 1)
        {
            GameController.GetPowerUp();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            GameController.GetPowerUp();
            source.PlayOneShot(upSound, 100);
        }
    }
}
