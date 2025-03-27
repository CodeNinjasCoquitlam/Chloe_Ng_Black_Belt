using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public string triggerName = "";

    public Stove stove;

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
                PickUpItem(breadPrefab, "breadSlice");
            }

            if(triggerName == "Egg")
            {
                PickUpItem(eggPrefab, "egg");
            }

            if (triggerName == "Stove")
            {
                if (heldItemName == "breadSlice")
                {
                    stove.ToastBread();
                    PlaceHeldItem();
                } 
                else if (heldItemName == "egg")
                {
                    stove.FryEgg();
                    PlaceHeldItem();
                }
                else
                {
                    if (stove.cookedFood == "toast")
                    {
                      if (stove.smokes == "0")
                        {
                            PickUpItem(FrenchToastPrefab, "Toast");
                            stove.CleanStove();
                        }
                    }
                    if (stove.cookedFood == "friedEgg")
                    {
                        if (stove.smokes == "0")
                        {
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
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Pudu/French Toast/toastSlice").SetActive(true);
                } else if (heldItemName == "friedEgg")
                {
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Pudu/French Toast/friedEgg").SetActive(true);
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
        } else
        {
            heldItem.transform.localScale = new Vector3(1, 1, 1);
        }

        heldItemName = itemName;
    }
}