using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    public Stove stove;

    [Header("Prefabs")]
    public GameObject toast;
    public GameObject friedEgg;

    [Header("Inventory")]
    public string cookedFood = "";

    [Header("Particles")]
    public ParticleSystem smoke;
    public ParticleSystem complete;
    public string smokes = "0";

    void Start()
    {
        toast.SetActive(false);
        friedEgg.SetActive(false);
    }

    public void ToastBread()
    {
        smoke.Play();
        smokes = "1";
        toast.SetActive(true);
        cookedFood = "toast";
        Invoke("CompleteCooking", 6f);
    }

    public void FryEgg()
    {
        smoke.Play();
        smokes = "1";
        friedEgg.SetActive(true);
        cookedFood = "friedEgg";
        Invoke("CompleteCooking", 8f);
    }

    public void CleanStove()
    {
        toast.SetActive(false);
        friedEgg.SetActive(false);
        cookedFood = "";
        complete.Stop();
    }

    private void CompleteCooking()
    {
        smoke.Stop();
        complete.Play();
        smokes = "0";
    }
}
