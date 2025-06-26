using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimersCountdown : MonoBehaviour
{
    public Text lapTime;
    public Interact inte;
    public static transfer GM;

    public float totalLapTime;

    void Update()
    {
        totalLapTime -= Time.deltaTime;
        lapTime.text = Mathf.Round(totalLapTime).ToString();
        totalLapTime -= Time.deltaTime;
        lapTime.text = Mathf.Round(totalLapTime).ToString();
        if (totalLapTime < 0)
        {
            lapTime.text = "0";
            transfer.score = inte.total;
            SceneManager.LoadScene(4);
        }
    }
}
