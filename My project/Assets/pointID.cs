using TMPro;
using UnityEngine;

public class pointID : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetScore(int value)
    {
        text.text = value.ToString();
    }

}
