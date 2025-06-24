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
    public GameObject Tp;
    public GameObject oneT; 
    public GameObject Fop;

    // Start is called before the first frame update
    void Start()
    {
        Sp.SetActive(false);
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
        Fp.SetActive(true);
        Tp.SetActive(false);
        oneT.SetActive(false);
        Fop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
