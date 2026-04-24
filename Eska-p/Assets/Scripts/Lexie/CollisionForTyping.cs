using UnityEngine;

public class CollisionForTyping : MonoBehaviour
{
    [SerializeField] playercontroller playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        playerController.SendChar(other.gameObject);
    }
}
