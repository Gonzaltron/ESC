using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [SerializeField] List<char> word;
    [SerializeField] List<char> CorrectWord;
    [SerializeField] GameObject door;
    [SerializeField] List<int>CharState;
    [SerializeField] List <TextMeshProUGUI> charWall;
    [SerializeField] List <GameObject> charWallObj;
    [SerializeField] Material correct;
    [SerializeField] Material wrong;
    [SerializeField] Material wrongPlace;
    [SerializeField] Material defaultMat;
    int index;
    int correctAmount;
    bool isComplete;
    int temp;
    int temp2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddChar(char character)
    {
        if(word.Count == CorrectWord.Count)
        {
            DeleteList();
        }
        word.Add(character);
        charWall[index].text = character.ToString();
        index ++;
        if(word.Count == CorrectWord.Count)
        {
            CheckLetra();
        }
    }
    public void CheckLetra()
    {
        for (int i = 0; i < CorrectWord.Count; i++)
        {
            if (word[i] == CorrectWord[i])
            {
                CharState.Add(1);
                correctAmount++;
            }
            else if (CorrectWord.Contains(word[i]))
            {
                CharState.Add(2);
            }
            else
            {
                CharState.Add(0);
            }
        }
        SolveWord();
    }
    void SolveWord()
    {
        for (int i = 0; i < CorrectWord.Count; i++)
        {
            switch (CharState[i])
            {
                case 0:
                    charWallObj[i].GetComponent<MeshRenderer>().material = wrong;
                    break;
                case 1:
                    charWallObj[i].GetComponent<MeshRenderer>().material = correct;
                    break;
                case 2:
                    charWallObj[i].GetComponent<MeshRenderer>().material = wrongPlace;
                    break;
            }
        }
        if(correctAmount == CorrectWord.Count)
        {
            door.SetActive(false);
        }
    }

    public void DeleteList()
    {
        if(!isComplete)
        {
            word.Clear();
            CharState.Clear();
            for(int i = 0; i < charWall.Count; i++)
            {
                charWall[i].text = " ";
                charWallObj[i].GetComponent<MeshRenderer>().material = defaultMat;
            }
            index = 0;
            correctAmount = 0;
        }
    }

    public void RemoveOne()
    {
        word.RemoveAt(index - 1);
        charWall[index - 1].text = " ";
        index --;
    }
}
