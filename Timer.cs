using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    bool isTimerOn = true;
    float remainingTime;
    float easyRemainingTime = 121f;
    float normalRemainingTime = 81f;
    float hardRemainingTime = 41f;
    public TextMeshProUGUI timer;

    public void Easy()
    {
        remainingTime = easyRemainingTime;
    }
    public void Normal()
    {
        remainingTime = normalRemainingTime;
    }
    public void Hard()
    {
        remainingTime = hardRemainingTime;
    }


    void Update()
    {
        if (isTimerOn == true)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;
                SceneManager.LoadScene("GameOver");
            }
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}
