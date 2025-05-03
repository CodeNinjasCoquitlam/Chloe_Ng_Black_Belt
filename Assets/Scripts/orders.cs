using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orders : MonoBehaviour
{
    //the orders:
    //"Egg and Ham Sandwich"
    //"Cookie"
    //"Cookie and Lemonade"
    //"Most complicated"
    //"Bread"
    //"Egg"
    //"Egg and Olives"
    //"Egg and Olives with lemonade"
    //"Bread with lemonade"
    //"Most complicated without lemonade"
    //"Egg with lemonade"
    //"Egg and Ham Sandwich with lemonade"
    //"Egg and Olive sandwich"
    //"Egg Olive Sandwich with lemonade"};
    public Vector3 startPos;
    public GameObject frenchtoast;
    public bool moving = false;
    public bool ordering = false;
    public bool cloned = false;
    public int randomNum;



    //Making the orders 

    // CHANGED BY SENSEI RYAN (WORKS)
    public List<string> orderssss = new List<string> {
      "COOKIE",
      "COOKIE_LEMONADE",
      "BREAD",
      "BREAD_OLIVE",
      "BREAD_LEMONADE",
      "BREAD_AND_HAM",
      "BREAD_AND_HAM_AND_OLIVE_LEMONADE",
      "EGG",
      "EGG_LEMONADE",
      "EGG_AND_OLIVE",
      "EGG_AND_OLIVE_LEMONADE",
      "EGG_SANDWICH",
      "EGG_SANDWICH_LEMONADE",
      "EGG_AND_HAM_SANDWICH",
      "EGG_AND_HAM_SANDWICH_LEMONADE",
      "EGG_AND_OLIVE_SANDWICH",
      "EGG_AND_OLIVE_SANDWICH_LEMONADE",
      "EGG_AND_HAM_AND_OLIVE_SANDWICH",
      "EGG_AND_HAM_AND_OLIVE_SANDWICH_LEMONADE"
};


    //actually code: order[14] list = {EGGNHAMSANDWICH, }



    //setting the ingredients up
    public class order
    {
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
        // order actually matters here for true and false game
        public order(bool eg, bool le, bool co, bool br, bool cr, bool ol)
        {
            this.egg = eg;
            this.leomonade = le;
            this.cookie = co;
            this.bread = br;
            this.cream = cr;
            this.olive = ol;
        }
    }

    void Start()
    {
        startPos = transform.position;
        frenchtoast = GameObject.Find("Receivers/Pudu/French Toast");

        string randomOrder = GetRandomOrder();
        Debug.Log("Order:" + randomOrder);

        string GetRandomOrder()
        {
            int index = Random.Range(0, orderssss.Count);
            return orderssss[index];
        }

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
                if (randomNum == 1)
                {
                    order COOKIE;

                } else if (randomNum == 2) {
                    
                } else if (randomNum == 3) {
                    
                } else if (randomNum == 4) {

                } else if (randomNum == 5) {

                } else if (randomNum == 6) {

                } else if (randomNum == 7) {

                } else if (randomNum == 8) {

                } else if (randomNum == 9) {

                } else if (randomNum == 10) {

                } else if (randomNum == 11) {

                } else if (randomNum == 12) {

                } else if (randomNum == 13) {

                } else if (randomNum == 14) {

                } else if (randomNum == 15) {

                } else if (randomNum == 16) {

                } else if (randomNum == 17) {

                } else if (randomNum == 18) {

                } else if (randomNum == 19) {

                } else if (randomNum == 20) {

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

//order COOKIE = new order(false, false, true, false, false, false);
//order COOKIE_LEMONADE = new order(false, true, true, false, false, false);
//order BREAD = new order(false, false, false, true, false, false);
//order BREAD_OLIVE = new order(false, false, false, true, false, true);
//order BREAD_LEMONADE = new order(false, true, false, true, false, false);
//order BREAD_AND_HAM = new order(false, false, false, true, true, false);
//order BREAD_AND_HAM_LEMONADE = new order(false, true, false, true, true, false);
//order BREAD_AND_HAM_AND_OLIVE = new order(false, false, false, true, true, true);
//order BREAD_AND_HAM_AND_OLIVE_LEMONADE = new order(false, true, false, true, true, true);
//order EGG = new order(true, false, false, false, false, false);
//order EGG_LEMONADE = new order(true, true, false, false, false, false);
//order EGG_AND_OLIVE = new order(true, false, false, false, false, true);
//order EGG_AND_OLIVE_LEMONADE = new order(true, true, false, false, false, true);
//order EGG_SANDWICH = new order(true, false, false, true, false, false);
//order EGG_AND_HAM_SANDWICH = new order(true, false, false, true, true, false);
//order EGG_AND_HAM_SANDWICH_LEMONADE = new order(true, true, false, true, true, false);
//order EGG_AND_OLIVE_SANDWICH = new order(true, false, false, true, false, true);
//order EGG_AND_OLIVE_SANDWICH_LEMONADE = new order(true, true, false, true, false, true);
//order EGG_AND_HAM_AND_OLIVE_SANDWICH = new order(true, false, false, true, true, true);
//order EGG_AND_HAM_AND_OLIVE_SANDWICH_LEMONADE = new order(true, true, false, true, true, true);