using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orders : MonoBehaviour
{
    //the orders:
//COOKIE
//COOKIE_LEMONADE
//BREAD
//BREAD_LEMONADE
//BREAD_OLIVE
//BREAD_HAM
//BREAD_HAM_LEMONADE
//BREAD_HAM_OLIVE
//BREAD_HAM_OLIVE_LEMONADE
//EGG
//EGG_LEMONADE
//EGG_OLIVE
//EGG_OLIVE_LEMONADE
//EGG_SANDWICH
//EGG_HAM_SANDWICH
//EGG_HAM_SANDWICH_LEMONADE
//EGG_OLIVE_SANDWICH
//EGG_OLIVE_SANDWICH_LEMONADE
//EGG_HAM_OLIVE_SANDWICH
//EGG_HAM_OLIVE_SANDWICH_LEMONADE
    public Vector3 startPos;
    public GameObject frenchtoast;
    public bool moving = false;
    public bool ordering = false;
    public bool cloned = false;
    public int randomNum;

    order COOKIE = new order("Cookie", false, false, true, false, false, false);
    order COOKIE_LEMONADE = new order("Cookie Lemonade", false, true, true, false, false, false);
    order BREAD = new order("Bread", false, false, false, true, false, false);
    order BREAD_LEMONADE = new order("Bread Lemonade", false, false, true, true, false, false);
    order BREAD_OLIVE = new order("Bread and Olive", false, false, false, true, false, true);
    order BREAD_HAM = new order("Bread and Ham", false, false, false, true, true, false);
    order BREAD_HAM_LEMONADE = new order ("Bread and Ham Lemonade", false, true, false, true, true, false);
    order BREAD_HAM_OLIVE = new order("Bread and Ham and Olive", false, false, false, true, true, true);
    order BREAD_HAM_OLIVE_LEMONADE = new order("Bread and Ham and Olive Lemonade", false, true, false, true, true, true);
    order EGG = new order("Egg", true, false, false, false, false, false);
    order EGG_LEMONADE = new order("Egg Lemonade", true, true, false, false, false, false);
    order EGG_OLIVE = new order("Egg and Olive", true, false, false, false, false, true);
    order EGG_OLIVE_LEMONADE = new order("Egg and Olive Lemonade", true, true, false, false, false, true);
    order EGG_SANDWICH = new order("Egg Sandwich", true, false, false, true, false, false);
    order EGG_HAM_SANDWICH = new order("Egg and Ham Sandwich", true, false, false, true, true, false);
    order EGG_HAM_SANDWICH_LEMONADE = new order("Egg and Ham Sandwich Lemonade", true, true, false, true, true, false);
    order EGG_OLIVE_SANDWICH = new order("Egg and Olive Sandwich", true, false, false, true, false, true);
    order EGG_OLIVE_SANDWICH_LEMONADE = new order("Egg and Olive Sandwich Lemonade", true, true, false, true, false, true);
    order EGG_HAM_OLIVE_SANDWICH = new order("Egg and Ham and Olive Sandwich", true, false, false, true, true, true);
    order EGG_HAM_OLIVE_SANDWICH_LEMONADE = new order("Egg and Ham and Olive Sandwich Lemonade", true, true, false, true, true, true);


    //Making the orders 

    // CHANGED BY SENSEI RYAN (WORKS)
//    public List<string> orderssss = new List<string> {
//      "COOKIE",
//      "COOKIE_LEMONADE",
//      "BREAD",
//      "BREAD_LEMONADE",
//      "BREAD_OLIVE",
//      "BREAD_AND_HAM",
//      "BREAD_AND_HAM_LEMONADE",
//      "BREAD_AND_HAM_AND_OLIVE",
//      "BREAD_AND_HAM_AND_OLIVE_LEMONADE",
//      "EGG",
//      "EGG_LEMONADE",
//      "EGG_AND_OLIVE",
//      "EGG_AND_OLIVE_LEMONADE",
//      "EGG_SANDWICH",
//      "EGG_AND_HAM_SANDWICH",
//      "EGG_AND_HAM_SANDWICH_LEMONADE",
//      "EGG_AND_OLIVE_SANDWICH",
//      "EGG_AND_OLIVE_SANDWICH_LEMONADE",
//      "EGG_AND_HAM_AND_OLIVE_SANDWICH",
//      "EGG_AND_HAM_AND_OLIVE_SANDWICH_LEMONADE"
//};


    //actually code: order[14] list = {EGGNHAMSANDWICH, }



    //setting the ingredients up
    public class order
    {
        string name;
        bool egg;
        bool leomonade;
        bool cookie;
        bool bread;
        bool cream;
        bool olive;

        public order()
        {
            //cant put anything in here (idk why)
        }
        // order actually matters here for true and false
        public order(string na, bool eg, bool le, bool co, bool br, bool cr, bool ol)
        {
            this.name = na;
            this.egg = eg;
            this.leomonade = le;
            this.cookie = co;
            this.bread = br;
            this.cream = cr;
            this.olive = ol;
        }

        public void DisplayName()
        {
            Debug.Log(this.name);
        }
    }

    void Start()
    {
        startPos = transform.position;
        frenchtoast = GameObject.Find("Receivers/Pudu/French Toast");

        //string randomOrder = GetRandomOrder();
        //Debug.Log("Order:" + randomOrder);

        //string GetRandomOrder()
        //{
        //    int index = Random.Range(0, orderssss.Count);
        //    return orderssss[index];
        //}

    }
    

    void Update()
    {
        if(ordering == true)
        {
            //turns it right
            transform.Rotate(Vector3.up * 60 * Time.deltaTime);
        }
        if(moving == true)
        {
            
            if(transform.position.z <= startPos.z)
            {
                //makes it move forward to the table    
                transform.position += new Vector3(0, 0, 1);
            } else
            {
                
                moving = false;
                randomNum = Random.Range(1, 20);

                if (randomNum == 1){
                    order COOKIE = new order("Cookie", false, false, true, false, false, false); ;
                    COOKIE.DisplayName();
                } else if (randomNum == 2) {
                    order COOKIE_LEMONADE = new order("Cookie Lemonade", false, true, true, false, false, false);
                    COOKIE_LEMONADE.DisplayName();
                } else if (randomNum == 3) {
                    order BREAD = new order("Bread", false, false, false, true, false, false);
                    BREAD.DisplayName();
                } else if (randomNum == 4) {
                    order BREAD_LEMONADE = new order("Bread Lemonade", false, false, true, true, false, false);
                    BREAD_LEMONADE.DisplayName();
                } else if (randomNum == 5) {
                    order BREAD_HAM = new order("Bread and Ham", false, false, false, true, true, false);
                    BREAD_HAM.DisplayName();
                } else if (randomNum == 6) {
                    order BREAD_HAM_LEMONADE = new order("Bread and Ham Lemonade", false, true, false, true, true, false);
                    BREAD_HAM_LEMONADE.DisplayName();
                } else if (randomNum == 7) {
                    order BREAD_OLIVE = new order("Bread and Olive", false, false, false, true, false, true);
                    BREAD_OLIVE.DisplayName();
                } else if (randomNum == 8) {
                    order BREAD_HAM_OLIVE = new order("Bread and Ham and Olive", false, false, false, true, true, true);
                    BREAD_HAM_OLIVE.DisplayName();
                } else if (randomNum == 9) {
                    order BREAD_HAM_OLIVE_LEMONADE = new order("Bread and Ham and Olive Lemonade", false, true, false, true, true, true);
                    BREAD_HAM_OLIVE_LEMONADE.DisplayName();
                } else if (randomNum == 10) {
                    order EGG = new order("Egg", true, false, false, false, false, false);
                    EGG.DisplayName();
                } else if (randomNum == 11) {
                    order EGG_LEMONADE = new order("Egg Lemonade", true, true, false, false, false, false);
                    EGG_LEMONADE.DisplayName();
                } else if (randomNum == 12) {
                    order EGG_OLIVE = new order("Egg and Olive", true, false, false, false, false, true);
                    EGG_OLIVE.DisplayName();
                } else if (randomNum == 13) {
                    order EGG_OLIVE_LEMONADE = new order("Egg and Olive Lemonade", true, true, false, false, false, true);
                    EGG_OLIVE_LEMONADE.DisplayName();
                } else if (randomNum == 14) {
                    order EGG_SANDWICH = new order("Egg Sandwich", true, false, false, true, false, false);
                    EGG_SANDWICH.DisplayName();
                } else if (randomNum == 15) {
                    order EGG_HAM_SANDWICH = new order("Egg and Ham Sandwich", true, false, false, true, true, false);
                    EGG_HAM_SANDWICH.DisplayName();
                } else if (randomNum == 16) {
                    order EGG_HAM_SANDWICH_LEMONADE = new order("Egg and Ham Sandwich Lemonade", true, true, false, true, true, false);
                    EGG_HAM_SANDWICH_LEMONADE.DisplayName();
                } else if (randomNum == 17) {
                    order EGG_OLIVE_SANDWICH = new order("Egg and Olive Sandwich", true, false, false, true, false, true);
                    EGG_OLIVE_SANDWICH.DisplayName();
                } else if (randomNum == 18) {
                    order EGG_OLIVE_SANDWICH_LEMONADE = new order("Egg and Olive Sandwich Lemonade", true, true, false, true, false, true);
                    EGG_OLIVE_SANDWICH_LEMONADE.DisplayName();
                } else if (randomNum == 19) {
                    order EGG_HAM_OLIVE_SANDWICH = new order("Egg and Ham and Olive Sandwich", true, false, false, true, true, true);
                    EGG_HAM_OLIVE_SANDWICH.DisplayName();
                } else if (randomNum == 20) {
                    order EGG_HAM_OLIVE_SANDWICH_LEMONADE = new order("Egg and Ham and Olive Sandwich Lemonade", true, true, false, true, true, true);
                    EGG_HAM_OLIVE_SANDWICH_LEMONADE.DisplayName();
                }
                //gameObject.FindChildByName("chocoCookie").setActive;
            }
        } 
        
        
        if (transform.rotation.eulerAngles.y >= 90)
        {
            //if it stopped turning right
            ordering = false;
            transform.position += new Vector3(0.5f, 0, 0);
            if (cloned == false)
            {
                //justs teleports it back
                Invoke("cloning", 2f);
                cloned = true;
            }
        }
        if (Input.GetKeyDown("v"))
        {
            //starts everything
            ordering = true;
        }

    }

    void cloning()
    {
        //transform.rotation = new Vector3(0, 0, 0);
        foreach (Transform child in frenchtoast.transform)
        {
            child.gameObject.SetActive(false);
        }
        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = startPos - new Vector3(0, 0, 10f);
        moving = true;
        cloned = false;
        
    }
}


//order COOKIE = new order("Cookie", false, false, true, false, false, false);
//order COOKIE_LEMONADE = new order("Cookie Lemonade", false, true, true, false, false, false);
//order BREAD = new order("Bread", false, false, false, true, false, false);
//order BREAD_LEMONADE = new order("Bread Lemonade", false, false, true, true, false, false);
//order BREAD_OLIVE = new order("Bread and Olive", false, false, false, true, false, true);
//order BREAD_HAM = new order("Bread and Ham", false, false, false, true, true, false);
//order BREAD_HAM_LEMONADE = new order"Bread and Ham Lemonade", (false, true, false, true, true, false);
//order BREAD_HAM_OLIVE = new order("Bread and Ham and Olive", false, false, false, true, true, true);
//order BREAD_HAM_OLIVE_LEMONADE = new order("Bread and Ham and Olive Lemonade", false, true, false, true, true, true);
//order EGG = new order("Egg", true, false, false, false, false, false);
//order EGG_LEMONADE = new order("Egg Lemonade", true, true, false, false, false, false);
//order EGG_OLIVE = new order("Egg and Olive", true, false, false, false, false, true);
//order EGG_OLIVE_LEMONADE = new order("Egg and Olive Lemonade", true, true, false, false, false, true);
//order EGG_SANDWICH = new order("Egg Sandwich", true, false, false, true, false, false);
//order EGG_HAM_SANDWICH = new order("Egg and Ham Sandwich", true, false, false, true, true, false);
//order EGG_HAM_SANDWICH_LEMONADE = new order("Egg and Ham Sandwich Lemonade", true, true, false, true, true, false);
//order EGG_OLIVE_SANDWICH = new order("Egg and Olive Sandwich", true, false, false, true, false, true);
//order EGG_OLIVE_SANDWICH_LEMONADE = new order("Egg and Olive Sandwich Lemonade", true, true, false, true, false, true);
//order EGG_HAM_OLIVE_SANDWICH = new order("Egg and Ham and Olive Sandwich", true, false, false, true, true, true);
//order EGG_HAM_OLIVE_SANDWICH_LEMONADE = new order("Egg and Ham and Olive Sandwich Lemonade", true, true, false, true, true, true);

