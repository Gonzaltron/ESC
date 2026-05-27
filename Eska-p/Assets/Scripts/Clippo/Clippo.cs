using UnityEngine;

public class Clippo : MonoBehaviour
{
    public static Clippo Instance;
    public InkManager inkManager;

    private string currentHint;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            inkManager.StartDialogue(currentHint);
        }
    }
    public void SetHint(string hintName)
    {
        currentHint = hintName;
    }
}