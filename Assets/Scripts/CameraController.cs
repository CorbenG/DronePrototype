using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothTime = 0.2f;
    public Transform target;
    private Vector3 _velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x + GameController.getPlayer().GetComponent<player_controller>().speed.x/6, 0, transform.position.z);


        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);

    }
}
