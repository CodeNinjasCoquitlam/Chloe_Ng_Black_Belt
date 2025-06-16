using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class nextPage : MonoBehaviour
{
    public void goTo2ndPage()
    {
        //work on this more
        //screenshot the 1st page and put it on a cube
        //then find the cube and make it false
        //screenshot the 2nd page and add it in :)))
        //remember dont put it in any folders!!!!
        //HOW WAS MUST ROCK WAS THE OTHER BANDS GOOD HOW DO YOU FEEL HOW WAS YOUR VOICE OK HOW WAS THE AUDIECE
        //no matter what u did amazing :):):):):)

        GameObject.Find("Sp").SetActive(true);
        GameObject.Find("1").SetActive(true);
        GameObject.Find("2").SetActive(true);
        GameObject.Find("3").SetActive(true);
        GameObject.Find("Fp").SetActive(false);

    }
}
