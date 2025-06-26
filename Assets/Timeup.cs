using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeup : MonoBehaviour
{
    public Text Score;
    public Text ScoreBackground;
    public static transfer GM;

    void Start()
    {
        
    }

    void Update()
    {
        Score.text = "Cash: $" + transfer.score;
        ScoreBackground.text = "Cash: $" + transfer.score;
    }
}
