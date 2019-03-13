using UnityEngine;
using UnityEngine.UI;

public class SerializeScore : MonoBehaviour
{
    public Text text1, text2, text3;

    int score1, score2, score3;

    MenuController controller;

    void Start()
    {
       controller = GetComponent<MenuController>();
       //ResetScore();
       LoadScore();
    }

    public void UpdateScore(int score)
    {
        // set new score if it is higher than current top scores
        if (score > score1) 
        {
            score3 = score2;
            score2 = score1;
            score1 = score;
        }
        else if (score > score2)
        {
            score3 = score2;
            score2 = score;
        } 
        else if (score > score3)
        {
            score3 = score;
        }

        // save score after updating
        SaveScore();
        SetScoreText();
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("score1", score1);
        PlayerPrefs.SetInt("score2", score2);
        PlayerPrefs.SetInt("score3", score3);
    }

    public void LoadScore()
    {
        score1 = PlayerPrefs.GetInt("score1");
        score2 = PlayerPrefs.GetInt("score2");
        score3 = PlayerPrefs.GetInt("score3");
    }

    public void SetScoreText()
    {
        text1.text = "1. " + score1 + " seconds";
        text2.text = "2. " + score2 + " seconds";
        text3.text = "3. " + score3 + " seconds";
    }

    void ResetScore()
    {
        PlayerPrefs.DeleteAll();
    }
}
