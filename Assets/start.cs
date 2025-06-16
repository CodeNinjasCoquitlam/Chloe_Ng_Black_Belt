using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    public GameObject Sp;
    public GameObject Fp;
    public GameObject one;
    public GameObject two;
    public GameObject three;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Sp").SetActive(false);
        GameObject.Find("one").SetActive(false);
        GameObject.Find("two").SetActive(false);
        GameObject.Find("three").SetActive(false);
        GameObject.Find("Fp").SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
