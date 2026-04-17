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
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player") && !isActive)
        {
            spawnEnemigos.SetActive(true);
            isActive = true;
        }
        else if (other.gameObject.CompareTag("player") && isActive)
        {
            spawnEnemigos.SetActive(false);
            isActive = false;
        }
    }
}
