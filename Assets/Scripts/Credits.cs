using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour
{
    
    public AudioSource clickCred;

    public void LoadCredits()
    {
        clickCred.Play();
        SceneManager.LoadScene(3);
    }

}
