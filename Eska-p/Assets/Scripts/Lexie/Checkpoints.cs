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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Spawn.Instance.SetCheckpoint(transform.position);
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.health = 3;
            }
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
