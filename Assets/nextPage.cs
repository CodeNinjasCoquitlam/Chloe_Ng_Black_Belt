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
    public GameObject oneT;
    public GameObject Fop;
    public int currentPage = 0;
    public void goTo2ndPage()
    {
        currentPage += 1;
        if(currentPage == 1)
        {
            //2nd pagee
            Sp.SetActive(true);
            one.SetActive(true);
            two.SetActive(true);
            three.SetActive(true);
            Fop.SetActive(false);
            
        } else if (currentPage == 2)
        {
            //3rd pagee
            Tp.SetActive(true);
            oneT.SetActive(true);
            Sp.SetActive(false);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);

        } else if (currentPage == 3)
        {
            //4th pagee
            Tp.SetActive(false);
            oneT.SetActive(false);
            Fop.SetActive(true);

        } else if (currentPage == 4)
        {
            //5th page
            Fop.SetActive(false);


        } else if (currentPage == 5)
        {
            //6th page

        }
        
    }
}
