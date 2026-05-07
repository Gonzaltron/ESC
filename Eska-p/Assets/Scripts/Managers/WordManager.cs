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
            deleteList();
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
        for (int i = 0; i< word.Count; i++)
        {
            
            for(int j = 0; j< CorrectWord.Count; j++)
            {
                if(word[i] == CorrectWord[j] && i == j)
                {
                    CharState.Add(1);
                    correctAmount ++;
                    charWallObj[i].GetComponent<MeshRenderer>().material = correct;
                    break;
                }
                else if(word[i] == CorrectWord[j] && i != j)
                {
                    if(charWallObj[i].GetComponent<MeshRenderer>().material != correct)
                    {
                        CharState.Add(2);
                        charWallObj[i].GetComponent<MeshRenderer>().material = wrongPlace;
                    }
                }
                else
                {
                    if(charWallObj[i].GetComponent<MeshRenderer>().material != correct && charWallObj[i].GetComponent<MeshRenderer>().material != wrongPlace)
                    {
                        CharState.Add(0);
                        charWallObj[i].GetComponent<MeshRenderer>().material = wrong;
                    }
                }
            }
            if(correctAmount == CorrectWord.Count)
            {
                door.SetActive(false);
                isComplete = true;
            }
            
        }
    }

    public void deleteList()
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
}
