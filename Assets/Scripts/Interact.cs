using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public string triggerName = "";

    public Stove stove;

    public AudioSource stoveSound;
    public AudioSource pickUp;
    public AudioSource putDown;
    public AudioSource trashAway;
    public AudioSource gooseSound;
    public GameObject trashPrefab;

    public GameObject Prefab;
    public GameObject olivePrefab;
    public GameObject lemonPrefab;
    public GameObject creamPrefab;
    public GameObject cookiePrefab;
    public GameObject breadPrefab;
    public GameObject eggPrefab;
    public GameObject friedEggPrefab;
    public GameObject FrenchToastPrefab;

    public GameObject heldItem;
    public string heldItemName;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (triggerName == "Bread")
            {
                pickUp.Play();
                PickUpItem(breadPrefab, "breadSlice");
            }

            if (triggerName == "Egg")
            {
                gooseSound.Play();
                PickUpItem(eggPrefab, "egg");
            }

            if (triggerName == "Lemonade")
            {
                pickUp.Play();
                PickUpItem(lemonPrefab, "lemonade");
            }

            if (triggerName == "Cream")
            {
                pickUp.Play();
                PickUpItem(creamPrefab, "cream");
            }
            if (triggerName == "Cookie")
            {
                pickUp.Play();
                PickUpItem(cookiePrefab, "cookie");
            }

            if (triggerName == "Olives")
            {
                pickUp.Play();
                PickUpItem(olivePrefab, "olive");
            }

            if (triggerName == "Trash")
            {

                trashAway.Play();
                PlaceHeldItem();
            }

            if (triggerName == "Stove")
            {
                if (heldItemName == "breadSlice")
                {
                    stoveSound.Play();
                    stove.ToastBread();
                    PlaceHeldItem();
                }
                else if (heldItemName == "egg")
                {
                    stoveSound.Play();
                    stove.FryEgg();
                    PlaceHeldItem();
                }
                else
                {
                    if (stove.cookedFood == "toast")
                    {
                        if (stove.smokes == "0")
                        {
                            pickUp.Play();
                            PickUpItem(FrenchToastPrefab, "Toast");
                            stove.CleanStove();
                        }
                    }
                    if (stove.cookedFood == "friedEgg")
                    {
                        if (stove.smokes == "0")
                        {
                            pickUp.Play();
                            PickUpItem(friedEggPrefab, "friedEgg");
                            stove.CleanStove();
                        }
                    }
                }
            }

            if (triggerName == "Receivers")
            {
                if (heldItemName == "Toast")
                {
                    putDown.Play();
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Pudu/French Toast/toastSlice").SetActive(true);
                }
                else if (heldItemName == "friedEgg")
                {
                    putDown.Play();
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Pudu/French Toast/friedEgg").SetActive(true);
                }
                else if (heldItemName == "cream")
                {
                    putDown.Play();
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Pudu/French Toast/Cream").SetActive(true);
                }
                else if (heldItemName == "lemonade")
                {
                    putDown.Play();
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Pudu/French Toast/Lemonade").SetActive(true);
                }
                else if (heldItemName == "cookie")
                {
                    putDown.Play();
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Pudu/French Toast/chocoCookie").SetActive(true);
                }
                else if (heldItemName == "olive")
                {
                    putDown.Play();
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Pudu/French Toast/olives").SetActive(true);
                }
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        triggerName = other.name;
    }

    private void OnTriggerExit(Collider other)
    {
        triggerName = "";
    }

    private void PlaceHeldItem()
    {
        Destroy(heldItem);
        heldItemName = "";
    }

    private void PickUpItem(GameObject itemPrefab, string itemName)
    {

        heldItem = Instantiate(itemPrefab, transform, false);
        heldItem.transform.localPosition = new Vector3(0, 0.2f, 0.5f);
        if (heldItem.tag == "Egg")
        {
            heldItem.transform.localScale = new Vector3(0.25f, 0.3f, 0.2f);
        }
        else
        {
            heldItem.transform.localScale = new Vector3(1, 1, 1);
        }

        heldItemName = itemName;
    }
}