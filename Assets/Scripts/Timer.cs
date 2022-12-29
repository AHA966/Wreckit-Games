using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timeLeft = 3.0f;
    public Text startText; //used for showing countdown from 3,2,1 


    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = "Time Left: " + (timeLeft).ToString("0") + "s";
        if (timeLeft < 0)
        {
         //Finish level and see who won?
        }
    }
}