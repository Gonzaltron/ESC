using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        door.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
