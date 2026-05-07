using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject spawnEnemigos;
    private bool isActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            spawnEnemigos.SetActive(true);
        }
    }
}
