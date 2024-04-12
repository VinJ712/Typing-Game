using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordBank : MonoBehaviour
{
    private List<string> originalWords = new List<string>()
    {
        "Mississippi", "Entrepreneur", "Accommodate", "Maintenance",
        "Rhythm", "Nausea", "Exacerbate", "Conscientious", "Paraphernalia",
        "Onomatopoeia", "Kaleidoscope", "Quixotic", "Serendipity", "Labyrinth",
        "Ephemeral"
    };

    private List<string> workingWords = new List<string>();


    void Awake()
    {
        workingWords.AddRange(originalWords);
        Shuffle(workingWords);
        ConvertToLowerCase(workingWords);
    }

    void Shuffle(List<string> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temporary = list[i];

            list[i] = list[random];
            list[random] = temporary;
        }
    }

    void ConvertToLowerCase(List<string> list)
    {
        for(int i = 0;i < list.Count; i++)
            list[i] = list[i].ToLower();
    }

    public string GetWord()
    {
        string newWord = string.Empty;

        if(workingWords.Count != 0)
        {
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        }
        else
        {
            SceneManager.LoadScene("Win");
        }

        return newWord;
    }
}
