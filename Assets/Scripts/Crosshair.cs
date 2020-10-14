using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Sprite noCross;
    public Sprite autoCross;
    public Sprite basicCross;
    public Sprite laserCross;
    public Sprite speedCross;
    public GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
        if (GameController.powerUp == "Auto Aim")
        {
            GetComponent<Image>().sprite = autoCross; 
        }
        else if (GameController.powerUp == "Laser")
        {
            GetComponent<Image>().sprite = laserCross;


        }
        else if (GameController.powerUp == "Gun")
        {
            GetComponent<Image>().sprite = basicCross;

        }
        else if (GameController.powerUp == "Speed Boost")
        {
            GetComponent<Image>().sprite = speedCross;

        }
        else if (GameController.powerUp == "N/A")
        {
            GetComponent<Image>().sprite = noCross;

        }
    }
}
