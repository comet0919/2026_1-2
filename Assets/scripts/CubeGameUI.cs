using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class CubeGameUI : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public float Timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        TimerText.text = "생존시간 : " + Timer.ToString("0.00");
    }
}
