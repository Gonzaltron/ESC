using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InkManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextAsset inkJSON;

    private Story story;
    void Awake()
    {
        story = new Story(inkJSON.text);
    }

    public void StartDialogue(string knotName)
    {
        story.ChoosePathString(knotName);
        ContinueStory();
    }

    public void ContinueStory()
    {
        if (story.canContinue)
        {
            dialogueText.text = story.Continue();
        }
    }
}
