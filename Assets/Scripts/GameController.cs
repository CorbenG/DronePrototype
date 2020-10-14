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
    public GameObject laser;
    private AudioSource source;
    public AudioClip fire;
    public AudioClip zoom;

    public static string powerUp = "N/A";
    public float autoAimDist;

    private static bool canShoot;
    public static float ammo;
    private int bullDelay = 0;

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
        player.transform.GetChild(0).gameObject.SetActive(false);

        if (powerUp == "Auto Aim")
        {
            if (Mathf.Sqrt(Mathf.Pow(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)).x - enemy.transform.position.x, 2) +
                Mathf.Pow(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)).y - enemy.transform.position.y, 2)) < autoAimDist)
            {
                enemy.transform.GetChild(0).gameObject.SetActive(true);
                if (Input.GetMouseButton(0) && canShoot)
                {
                    GameObject miss = Instantiate(missile, player.transform.position, player.transform.rotation);
                    miss.GetComponent<Missile>().initSpeed = player.GetComponent<player_controller>().rb.velocity;
                    canShoot = false;
                    source.PlayOneShot(fire);
                    powerUp = "N/A";
                }
            }
           
        }
        else if (powerUp == "Laser")
        {
            player.transform.GetChild(0).gameObject.SetActive(true);
            if (Input.GetMouseButton(0) && canShoot)
            {
                Instantiate(laser, player.transform);
                canShoot = false;
                powerUp = "N/A";
            }

        }
        else if (powerUp == "Gun")
        {
            if(Input.GetMouseButton(0) && bullDelay >= 5)
            {
                bullDelay = 0;
            }
            else if(Input.GetMouseButton(0))
            {
                bullDelay++;
            }
            if (Input.GetMouseButton(0) && canShoot && ammo > 0 && bullDelay == 0)
            {
                GameObject bull = Instantiate(bullet, player.transform.position, player.transform.rotation);
                bull.GetComponent<Bullet>().initVel = player.GetComponent<player_controller>().rb.velocity;
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
            if (Input.GetMouseButton(0) && canShoot)
            {
                player.GetComponent<player_controller>().speedBoost = 60;
                canShoot = false;
                powerUp = "N/A";
            }
        }
        else if (powerUp == "N/A")
        {

        }
        powerupText.text = "Power-Up: " + powerUp;
    }

    public static void GetPowerUp()
    {
        if(powerUp == "N/A")
        {
            int value = Random.Range(0, 4);
            Debug.Log(value);
            if (value == 0)
            {
                powerUp = "Laser";
            }
            else if (value == 1)
            {
                powerUp = "Gun";
                ammo = 100;
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

            canShoot = true;
            //Set player can shoot power up to true
        }

    }

    public static GameObject getEnemy()
    {
        return GameObject.Find("Enemy");
    }

    public static GameObject getPlayer()
    {
        return GameObject.Find("Player");
    }
}
