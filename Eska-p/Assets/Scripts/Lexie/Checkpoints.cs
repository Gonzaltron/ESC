using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private GameObject player;
    public Vector3 spawnPosition;
    private Player lexi;
    [SerializeField] private Spawn spawnScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = spawnScript.player; // El problema viene de que cojo el del prefab y no acutaliza
        lexi = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        NextSpawn();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            spawnPosition = player.transform.position;
        }
    }
    public void NextSpawn()
    {
        if (lexi.GetComponent<Player>().isDead == true)
        {
            player.transform.position = spawnPosition;
        }
    }
}
