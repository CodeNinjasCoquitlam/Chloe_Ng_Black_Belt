using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimersCountdown : MonoBehaviour
{
    public Text lapTime;


    public float totalLapTime;

    void Update()
    {
        totalLapTime -= Time.deltaTime;

        lapTime.text = Mathf.Round(totalLapTime).ToString();

        totalLapTime -= Time.deltaTime;
        lapTime.text = Mathf.Round(totalLapTime).ToString();
        
        if (totalLapTime < 0)
        {
            lapTime.text = "Time is up!";

            SceneManager.LoadScene(1);
        }
    }
}
