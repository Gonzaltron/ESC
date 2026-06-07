using UnityEngine;
using Unity.Cinemachine;

public class Camera : MonoBehaviour
{
    CinemachineThirdPersonFollow vCam;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        vCam = GameObject.Find("Virtual Camera").GetComponent<CinemachineThirdPersonFollow>();
        vCam.AvoidObstacles.DampingIntoCollision = 10f;
        vCam.AvoidObstacles.DampingFromCollision = 0f;
    }
}
