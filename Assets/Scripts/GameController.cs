using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text powerupText;
    public GameObject player;

    public static string powerUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetPowerUp();
            powerupText.text = "Power-Up: " + powerUp;
        }
    }

    public static void GetPowerUp()
    {
        int value = Random.Range(0, 5);
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
}
