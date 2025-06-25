using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Interact : MonoBehaviour
{
    public string triggerName = "";

    public Stove stove;
    public Text moneyEarned;

    public AudioSource stoveSound;
    public AudioSource pickUp;
    public AudioSource putDown;
    public AudioSource trashAway;
    public AudioSource gooseSound;
    public GameObject trashPrefab;
    public int total = 0;

    public GameObject Prefab;
    public GameObject olivePrefab;
    public GameObject lemonPrefab;
    public GameObject creamPrefab;
    public GameObject cookiePrefab;
    public GameObject breadPrefab;
    public GameObject eggPrefab;
    public GameObject friedEggPrefab;
    public GameObject FrenchToastPrefab;
    public orders OrderManager;

    public GameObject heldItem;
    public string heldItemName;
    private List<string> ingredientsGathered;

    void Start()
    {
        ingredientsGathered = new List<string>();
    }
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
                PickUpItem(olivePrefab, "olives");
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
                ingredientsGathered.Add(heldItemName);
                if (heldItemName == "Toast")
                {
                    Debug.Log("toast added");


                    //for (int i = 0; i < ingredientsGathered.Count; i++){

                      //  Debug.Log(ingredientsGathered[i]);
                    
                    //}


                    putDown.Play();
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Pudu/French Toast/toastSlice").SetActive(true);
                    OrderManager.hasFood = true;
                    if (OrderManager.randomNum == 3)
                    {
                        if (ingredientsGathered.Contains("Toast"))
                        {
                            total += OrderManager.price;
                            Debug.Log("Bread");
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();

                            ingredientsGathered.Clear();
                        }
                        
                    }
                    else if (OrderManager.randomNum == 4)
                        {
                            if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("lemonade"))
                            {
                                total += OrderManager.price;
                                Debug.Log("Bread lemonade");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();

                            }
                        }
                    else if (OrderManager.randomNum == 5)
                        {
                            if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("cream"))
                            {
                                total += OrderManager.price;
                                Debug.Log("Bread + ham");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();
                            }
                        }
                    else if (OrderManager.randomNum == 6)
                        {
                            if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("lemonade"))
                            {
                                total += OrderManager.price;
                                Debug.Log("Bread + ham lemonade");
                                Debug.Log(total);
                                moneyEarned.text = "$" + total.ToString();
                                ingredientsGathered.Clear();
                            }
                        }
                    else if (OrderManager.randomNum == 7)
                        {
                            if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("olive"))
                            {
                                total += OrderManager.price;
                                moneyEarned.text = "$" + total.ToString();
                                Debug.Log("Bread olive");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();
                            }
                        }
                    else if (OrderManager.randomNum == 8)
                        {
                            if(ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("Toast"))
                            {
                                total += OrderManager.price;
                                Debug.Log("olive + ham sandwich");
                                Debug.Log(total);
                                moneyEarned.text = "$" + total.ToString();
                                ingredientsGathered.Clear();
                            }
                        }
                    else if (OrderManager.randomNum == 9)
                        {
                            if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("lemonade"))
                            {
                                total += OrderManager.price;
                                Debug.Log("olive + ham sandwich lemonade");
                                Debug.Log(total);
                                moneyEarned.text = "$" + total.ToString();
                                ingredientsGathered.Clear();
                            }
                        }
                    else if (OrderManager.randomNum == 14)
                        {
                            if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("friedEgg"))
                            {
                                total += OrderManager.price;
                                Debug.Log("egg sandwich");
                                Debug.Log(total);
                                moneyEarned.text = "$" + total.ToString();
                                ingredientsGathered.Clear();
                            }
                        }
                    else if (OrderManager.randomNum == 15)
                        {
                            if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("cream"))
                            {
                                total += OrderManager.price;
                                Debug.Log("egg ham sandwich");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();
                        }
                        }
                    else if (OrderManager.randomNum == 16)
                        {
                            if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("lemonade"))
                            {
                                total += OrderManager.price;
                                Debug.Log("egg ham sandwich lemonade");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();
                        }
                        }
                    else if (OrderManager.randomNum == 17)
                        {
                            if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("Toast"))
                            {
                                total += OrderManager.price;
                                Debug.Log("olive + egg sandwich");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();
                            }
                        }
                    else if (OrderManager.randomNum == 18)
                        {
                            if (ingredientsGathered.Contains("olive")&& ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("lemonade"))
                            {
                                total += OrderManager.price;
                                Debug.Log("olive + egg sandwich lemonade");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();
                            }
                        }
                    else if (OrderManager.randomNum == 19)
                        {
                            if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("FriedEgg") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("cream"))
                        {
                                total += OrderManager.price;
                                Debug.Log("olive + egg + ham sandwich");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();


                        }
                        }
                    else if (OrderManager.randomNum == 20)
                        {
                            if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("lemonade"))
                        {
                                total += OrderManager.price;
                                Debug.Log("olive + egg + ham sandwich lemonade");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();

                        }
                        }
                }
                else if (heldItemName == "friedEgg")
                {

                    Debug.Log("egg added");
                    putDown.Play();
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Pudu/French Toast/friedEgg").SetActive(true);
                    OrderManager.hasFood = true;
                    if (OrderManager.randomNum == 10)
                    {
                        if (ingredientsGathered.Contains("friedEgg"))
                        {
                            total += OrderManager.price;
                            Debug.Log("egg");
                            Debug.Log(total);
                            ingredientsGathered.Clear();
                            moneyEarned.text = "$" + total.ToString();

                        }
                        
                    }
                    else if (OrderManager.randomNum == 11)
                        {
                            if (ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("lemonade"))
                            {
                                total += OrderManager.price;
                                Debug.Log("egg lemonade");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();

                        }
                        }
                    else if (OrderManager.randomNum == 12)
                        {
                            if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("egg"))
                            {
                                total += OrderManager.price;
                                Debug.Log("olive + egg");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();

                        }
                        }
                    else if (OrderManager.randomNum == 13)
                        {
                            if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("lemonade"))
                            {
                                total += OrderManager.price;
                                Debug.Log("olive + egg lemonade");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();

                        }
                        }
                    else if (OrderManager.randomNum == 14)
                        {
                            if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("friedEgg"))
                            {
                                total += OrderManager.price;
                                Debug.Log("egg sandwich");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();
                            }
                        }
                    else if (OrderManager.randomNum == 15)
                        {
                            if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("cream"))
                            {
                                total += OrderManager.price;
                                Debug.Log("egg ham sandwich");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();
                            }
                        }
                    else if (OrderManager.randomNum == 16)
                        {
                            if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("lemonade"))
                            {
                                total += OrderManager.price;
                                Debug.Log("egg ham sandwich lemonade");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();

                            }
                        }
                    else if (OrderManager.randomNum == 17)
                        {
                            if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("Toast"))
                            {
                                total += OrderManager.price;
                                Debug.Log("olive + egg sandwich");
                                Debug.Log(total);
                                ingredientsGathered.Clear();
                                moneyEarned.text = "$" + total.ToString();
                            
                            }
                        }
                    else if (OrderManager.randomNum == 18)
                        {
                            if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("lemonade"))
                            {
                                total += OrderManager.price;
                                Debug.Log("olive + egg sandwich lemonade");
                                ingredientsGathered.Clear();
                                Debug.Log(total);
                                moneyEarned.text = "$" + total.ToString();
                            
                            }
                        }
                    else if (OrderManager.randomNum == 19)
                        {
                            if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("FriedEgg") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("cream"))
                            {
                                total += OrderManager.price;
                                Debug.Log("olive + egg + ham sandwich");
                                ingredientsGathered.Clear();
                                Debug.Log(total);
                                moneyEarned.text = "$" + total.ToString();

                            }
                        }
                    else if (OrderManager.randomNum == 20)
                        {
                            if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("lemonade"))
                            {
                                total += OrderManager.price;
                                Debug.Log("olive + egg + ham sandwich lemonade");
                                ingredientsGathered.Clear();
                                Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                            //
                            }
                        }
                }
                else if (heldItemName == "cream")
                {
                    Debug.Log("cream added");
                    putDown.Play();
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Pudu/French Toast/Cream").SetActive(true);
                    OrderManager.hasFood = true;
                    if (OrderManager.randomNum == 5)
                    {
                        if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("cream"))
                        {
                            total += OrderManager.price;
                            Debug.Log("Bread + ham");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                        

                    }
                    else if (OrderManager.randomNum == 6)
                        {
                            if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("lemonade"))
                            {
                                total += OrderManager.price;
                                Debug.Log("Bread + ham lemonade");
                                ingredientsGathered.Clear();
                                Debug.Log(total);
                            }
                        }
                    else if (OrderManager.randomNum == 8)
                        {
                            if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("Toast"))
                            {
                                total += OrderManager.price;
                                Debug.Log("olive + ham sandwich");
                                ingredientsGathered.Clear();
                                Debug.Log(total);
                                moneyEarned.text = "$" + total.ToString();
                            //
                            }
                        } 
                    else if (OrderManager.randomNum == 9)
                        {
                            if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("lemonade"))
                            {
                                total += OrderManager.price;
                                Debug.Log("olive + ham sandwich lemonade");
                                ingredientsGathered.Clear();
                                Debug.Log(total);
                                moneyEarned.text = "$" + total.ToString();
                            
                            }
                        }
                    else if (OrderManager.randomNum == 15)
                        {
                            if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("cream"))
                            {
                                total += OrderManager.price;
                                Debug.Log("egg ham sandwich");

                                ingredientsGathered.Clear();
                                Debug.Log(total);
                                moneyEarned.text = "$" + total.ToString();
                            }
                        }
                    else if (OrderManager.randomNum == 16)
                        {
                            if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("lemonade"))
                            {
                                total += OrderManager.price;
                                Debug.Log("egg ham sandwich lemonade");
                                ingredientsGathered.Clear();
                                Debug.Log(total);
                                moneyEarned.text = "$" + total.ToString();

                            }
                        }
                    else if (OrderManager.randomNum == 19)
                        {
                            if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("FriedEgg") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("cream"))
                            {
                                total += OrderManager.price;
                                Debug.Log("olive + egg + ham sandwich");
                                ingredientsGathered.Clear();
                                Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                            }
                        }
                    else if (OrderManager.randomNum == 20)
                        {
                            if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("lemonade"))
                            {
                                total += OrderManager.price;
                                Debug.Log("olive + egg + ham sandwich lemonade");
                                ingredientsGathered.Clear();
                                Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                            }
                        }
                }
                else if (heldItemName == "lemonade")
                {

                    Debug.Log("lemonade added");
                    putDown.Play();
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Pudu/French Toast/Lemonade").SetActive(true);
                    OrderManager.hasFood = true;
                    if (OrderManager.randomNum == 2)
                    {
                        if (ingredientsGathered.Contains("cookie") && ingredientsGathered.Contains("lemonade"))
                        {
                            total += OrderManager.price;
                            Debug.Log("Cookie + lemonade");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 4)
                    {
                        if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("lemonade"))
                        {
                            total += OrderManager.price;
                            Debug.Log("Bread lemonade");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 6)
                    {
                        if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("lemonade"))
                        {
                            total += OrderManager.price;
                            Debug.Log("Bread + ham lemonade");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 9)
                    {
                        if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("lemonade"))
                        {
                            total += OrderManager.price;
                            Debug.Log("olive + ham sandwich lemonade");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 11)
                    {
                        if (ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("lemonade"))
                        {
                            total += OrderManager.price;
                            Debug.Log("egg lemonade");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 13)
                    {
                        if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("lemonade"))
                        {
                            total += OrderManager.price;
                            Debug.Log("olive + egg lemonade");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 16)
                    {
                        if (ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("lemonade"))
                        {
                            total += OrderManager.price;
                            Debug.Log("egg ham sandwich lemonade");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 18)
                    {
                        if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("lemonade"))
                        {
                            total += OrderManager.price;
                            Debug.Log("olive + egg sandwich lemonade");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 20)
                    {
                        if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("lemonade"))
                        {
                            total += OrderManager.price;
                            Debug.Log("olive + egg + ham sandwich lemonade");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                }
                else if (heldItemName == "cookie")
                {

                    Debug.Log("cookie added");
                    putDown.Play();
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Pudu/French Toast/chocoCookie").SetActive(true);
                    OrderManager.hasFood = true;
                    if (OrderManager.randomNum == 1 )
                    {
                        //just checking
                        Debug.Log("cookie added to order (correct)");


                        if (ingredientsGathered.Contains("cookie"))
                        {
                            total += OrderManager.price;
                            Debug.Log("Cookie");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                        //Sensei Matthew: the next thing to do, is fill out all of the other order cases.
                        //for example, if randomNum == 2, the order is Cookie and Lemonade, so we need to
                        //check if cookie and Lemonade both exist (are contained) in the 'ingedientsGathered' List
                        //if they both are, add the price of the order to total.
                    }
                    else if(OrderManager.randomNum == 2){
                        if (ingredientsGathered.Contains("cookie") && ingredientsGathered.Contains("lemonade"))
                        {
                            total += OrderManager.price;
                            Debug.Log("Cookie + lemonade");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                }
                else if (heldItemName == "olive")
                {

                    Debug.Log("olive added");
                    putDown.Play();
                    PlaceHeldItem();
                    GameObject.Find("Receivers/Pudu/French Toast/olive").SetActive(true);
                    OrderManager.hasFood = true;
                    if (OrderManager.randomNum == 7)
                    {
                        if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("Toast"))
                        {
                            total += OrderManager.price;
                            Debug.Log("Olive sandwich");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 8)
                    {
                        if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("Toast"))
                        {
                            total += OrderManager.price;
                            Debug.Log("olive + ham sandwich");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 9)
                    {
                        if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("lemonade"))
                        {
                            total += OrderManager.price;
                            Debug.Log("olive + ham sandwich lemonade");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 12)
                    {
                        if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("egg"))
                        {
                            total += OrderManager.price;
                            Debug.Log("olive + egg");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 13)
                    {
                        if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("lemonade"))
                        {
                            total += OrderManager.price;
                            Debug.Log("olive + egg lemonade");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 17)
                    {
                        if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("Toast"))
                        {
                            total += OrderManager.price;
                            Debug.Log("olive + egg sandwich");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 18)
                    {
                        if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("lemonade"))
                        {
                            total += OrderManager.price;
                            Debug.Log("olive + egg sandwich lemonade");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 19)
                    {
                        if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("FriedEgg") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("cream"))
                        {
                            total += OrderManager.price;
                            Debug.Log("olive + egg + ham sandwich");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
                    else if (OrderManager.randomNum == 20)
                    {
                        if (ingredientsGathered.Contains("olive") && ingredientsGathered.Contains("friedEgg") && ingredientsGathered.Contains("Toast") && ingredientsGathered.Contains("cream") && ingredientsGathered.Contains("lemonade"))
                        {
                            total += OrderManager.price;
                            Debug.Log("olive + egg + ham sandwich lemonade");
                            ingredientsGathered.Clear();
                            Debug.Log(total);
                            moneyEarned.text = "$" + total.ToString();
                        }
                    }
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