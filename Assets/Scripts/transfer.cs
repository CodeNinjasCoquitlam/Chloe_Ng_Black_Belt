using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transfer : MonoBehaviour
{
    public static int score;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
