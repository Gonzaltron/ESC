using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawn;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("spawn");
        SpawnPlayerFirstTime();

    }
    public void SpawnPlayerFirstTime()
    {
        GameObject.Instantiate(player, spawn.transform.position, Quaternion.identity);
    }

    public void NewSpawn()
    {
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
