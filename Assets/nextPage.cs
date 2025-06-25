using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class nextPage : MonoBehaviour
{
    public GameObject Sp;
    public GameObject Fp;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject Tp;
    public GameObject onet;
    public GameObject Fop;
    public GameObject Fivp;
    public GameObject onef;
    public int currentPage = 0;
    public void goTo2ndPage()
    {
        currentPage += 1;
        if(currentPage == 1)
        {
            //2nd pagee
            Debug.Log("2nd page");
            Sp.SetActive(true);
            one.SetActive(true);
            two.SetActive(true);
            three.SetActive(true);
            Fp.SetActive(false);
            
        } else if (currentPage == 2)
        {
            //3rd pagee
            Debug.Log("3rd page");
            Tp.SetActive(true);
            onet.SetActive(true);
            Sp.SetActive(false);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);

        } else if (currentPage == 3)
        {
            //4th pagee
            Debug.Log("4th page");
            Tp.SetActive(false);
            onet.SetActive(false);
            Fop.SetActive(true);

        } else if (currentPage == 4)
        {
            //5th page
            Debug.Log("5th page");
            Fop.SetActive(false);
            Fivp.SetActive(true);
            onef.SetActive(true);
            

        } else if (currentPage == 5)
        {
            //1st page
            Debug.Log("1st page");
            Fivp.SetActive(false);
            onef.SetActive(false);
            Fp.SetActive(true);
            currentPage -= 5;
        }
        
    }
}
