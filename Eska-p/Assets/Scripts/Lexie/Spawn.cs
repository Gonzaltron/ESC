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
        player = Instantiate(player, spawn.transform.position, Quaternion.identity);
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
