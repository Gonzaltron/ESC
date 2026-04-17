using Ink.Runtime;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawn;
    public GameObject player;
    public static Spawn Instance;
    private Vector3 lastCheckpoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("spawn");
        SpawnPlayerFirstTime();
    }
    public void SpawnPlayerFirstTime()
    {
        player = Instantiate(player, spawn.transform.position, Quaternion.identity);
    }
    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpoint = checkpointPosition;
    }

    public void Respawn()
    {
        Debug.Log("respawn");
        player.transform.position = lastCheckpoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
