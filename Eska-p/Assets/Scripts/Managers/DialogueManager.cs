using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && InkManager.Instance.isTyping == true)
        {
            InkManager.Instance.AutomaticDialogue();
        }
        else if (Input.GetMouseButtonDown(0) && InkManager.Instance.isTyping == false)
        {
            InkManager.Instance.EndDialogue();
        }
    }
}
