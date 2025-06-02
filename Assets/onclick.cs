using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclick : MonoBehaviour
{
    public AudioSource clickDuck;

    public void DoDaDuck()
    {
        clickDuck.Play();
    }
}
