using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private int ScoreNumber;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNumber = 0;
        scoreText.text = "Score: " + ScoreNumber;
    }

    public void setScore(int score){
        ScoreNumber = score;
        scoreText.text = "Score: " + ScoreNumber;
    }


}
