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

    public bool ordering = false;

    //Making the orders 
    order EGG = new order(true, false, false, false, false, false);
    order EGG_LEMONADE = new order(true, true, false, false, false, false);
    order EGG_AND_OLIVE = new order(true, false, false, false, false, true);
    order EGG_AND_OLIVE_LEMONADE = new order(true, true, false, false, false, true);
    order EGG_SANDWICH = new order(true, false, false, true, false, false);
    order EGG_SANDWICH_LEMONADE = new order(true, true, false, true, false, false);
    order EGG_AND_HAM_SANDWICH = new order(true, false, false, true, true, false);
    order EGG_AND_HAM_SANDWICH_LEMONADE = new order(true, true, false, true, true, false);
    order EGG_AND_OLIVE_SANDWICH = new order(true, false, false, true, false, true);
    order EGG_AND_OLIVE_SANDWICH_LEMONADE = new order(true, true, false, true, false, true);
    order EGG_AND_HAM_AND_OLIVE_SANDWICH = new order(true, false, false, true, true, true);
    order EGG_AND_HAM_AND_OLIVE_SANDWICH_LEMONADE = new order(true, true, false, true, true, true);


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

    

    void Update()
    {
        if(ordering == true)
        {
            transform.Rotate(Vector3.up * 60 * Time.deltaTime);
        }
        
        if (transform.rotation.eulerAngles.y >= 90)
        {
            ordering = false;
            transform.position += new Vector3(0.5f, 0, 0);
            Invoke("cloning", 1.0f);
        }

    }

    void cloning()
    {
        //Instantiate()
    }
}
