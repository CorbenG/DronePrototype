using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text powerupText;
    public GameObject player;
    public GameObject enemy;
    public GameObject crosshair;
    public GameObject missile;
    public GameObject bullet;
    private AudioSource source;
    public AudioClip fire;

    public static string powerUp;
    public float autoAimDist;

    private bool canShoot;
    float ammo;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetPowerUp();
            ammo = 100;
            canShoot = true;
        }

        enemy.transform.GetChild(0).gameObject.SetActive(false);

        if (powerUp == "Auto Aim")
        {
            if (Mathf.Sqrt(Mathf.Pow(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)).x - enemy.transform.position.x, 2) +
                Mathf.Pow(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)).y - enemy.transform.position.y, 2)) < autoAimDist)
            {
                enemy.transform.GetChild(0).gameObject.SetActive(true);
                if (Input.GetMouseButton(0) && canShoot)
                {
                    Instantiate(missile, player.transform.position, player.transform.rotation);
                    canShoot = false;
                    source.PlayOneShot(fire);
                    powerUp = "N/A";
                }
            }
           
        }
        else if (powerUp == "Laser")
        {


        }
        else if (powerUp == "Gun")
        {
            if (Input.GetMouseButton(0) && canShoot && ammo > 0)
            {
                Instantiate(bullet, player.transform.position, player.transform.rotation);
                ammo--;
                source.PlayOneShot(fire);
            }
            if(ammo <= 0)
            {
                canShoot = false;
                powerUp = "N/A";
            }
        }
        else if (powerUp == "Speed Boost")
        {

        }
        else if (powerUp == "N/A")
        {

        }
        powerupText.text = "Power-Up: " + powerUp;
    }

    public static void GetPowerUp()
    {
        int value = Random.Range(0, 4);
        if(value == 0)
        {
           powerUp =  "Laser";
        }
        else if (value == 1)
        {
            powerUp = "Gun";
        }
        else if (value == 2)
        {
            powerUp = "Auto Aim";
        }
        else if (value == 3)
        {
            powerUp = "Speed Boost";
        }
        else
        {
            powerUp = "N/A";
        }

        
        //Set player can shoot power up to true
    }

    public static GameObject getEnemy()
    {
        return GameObject.Find("Enemy");
    }
}
