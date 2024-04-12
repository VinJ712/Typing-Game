using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    public WordBank wordBank = null;
    public TextMeshProUGUI wordOutput = null;

    string remainingWord = string.Empty;
    string currentWord = string.Empty;

    [Header("BgImage")]
    public Animator bgAnimator;
    public SpriteRenderer bgRenderer;

    [Header("SFX")]
    public AudioSource wrongSfx;
    public AudioSource keyPressSfx;


    void Start()
    {
        bgAnimator = FindObjectOfType<Animator>();   
        SetCurrentWord();
    }

    void SetCurrentWord()
    {
        currentWord = wordBank.GetWord();
        SetRemainingWord(currentWord);
    }

    void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }

    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;

            if (keyPressed.Length == 1)
            {
                keyPressSfx.Play();
                EnterLetter(keyPressed);
            }
            else
            {
                StartCoroutine(isWrongInput());
            }
                
        }
    }

    IEnumerator isWrongInput()
    {
        wrongSfx.Play();
        bgAnimator.SetBool("isWrong", true);
        bgRenderer.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        bgAnimator.SetBool("isWrong", false);
        bgRenderer.color = Color.white;
    }

    void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();
            if (IsWordComplete())
            {
                SetCurrentWord();
            }
                
        }
        else
        {
            StartCoroutine(isWrongInput());
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0; 
    }

    void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }

}
