using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetScore(int value)
    {
        text.text = value.ToString();
    }


}
