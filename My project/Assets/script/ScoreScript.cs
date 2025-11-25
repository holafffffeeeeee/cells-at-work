using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI text;

    public TextMeshProUGUI finalScore;
    public void SetScore(int value)
    {
        text.text = value.ToString();
     
           
    }
    public void finalscore(int value)
    {
        finalScore.text = value.ToString("score: " + value);
    }

}
