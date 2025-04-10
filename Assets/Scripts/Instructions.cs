using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Instructions : MonoBehaviour
{

    public AudioSource clickInstru;


    public void LoadInstructions()
    {
        clickInstru.Play();
        SceneManager.LoadScene(2);
    }

}

