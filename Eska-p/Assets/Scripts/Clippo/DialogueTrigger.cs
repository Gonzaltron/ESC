using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string knotName;
    public string clueName;

    public InkManager inkManager;
    public Player player;

    private bool activated = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player") && !activated)
        {
            activated = true;
            Clippo.Instance.SetHint(clueName);
            inkManager.StartDialogue(knotName);
            player.health = 3;

            Spawn.Instance.SetCheckpoint(transform.position);
        }
    }
}