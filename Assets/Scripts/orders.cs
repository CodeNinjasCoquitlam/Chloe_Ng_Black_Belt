using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class orders : MonoBehaviour
{
    #region Variables
    public Vector3 startPos;
    public GameObject frenchtoast;
    public Text orderName;
    public bool moving = false;
    public bool ordering = false;
    public bool cloned = false;
    public int randomNum;
    public bool hasFood = false;
    public int price;
    public Image currentOrderPhoto;
    public Sprite[] orderPhotos;
    public AudioSource PuduCameBack;
    private order currentOrder;
    
    #endregion

    public class order
    {
        string name;
        bool egg;
        bool lemonade;
        bool cookie;
        bool bread;
        bool cream;
        bool olive;

        orders parent;

        public order(string na, bool eg, bool le, bool co, bool br, bool cr, bool ol, orders parentRef)
        {
            this.name = na;
            this.egg = eg;
            this.lemonade = le;
            this.cookie = co;
            this.bread = br;
            this.cream = cr;
            this.olive = ol;
            this.parent = parentRef;
        }

        public void DisplayName()
        {
            //shows the order on screen (text)
            Debug.Log(this.name);
            parent.orderName.text = this.name;
        }
    }

    void Start()
    {
        startPos = transform.position;
        frenchtoast = GameObject.Find("Receivers/Pudu/French Toast");
        genOrders();
    }

    void Update()
    {
        if (ordering == true)
        {
            //turns it right
            transform.Rotate(Vector3.up * 60 * Time.deltaTime);
        }
        if (moving == true)
        {
            if (transform.position.z <= startPos.z)
            {
                //moves forward
                transform.position += new Vector3(0, 0, 1);
                PuduCameBack.Play();
            }
            else
            {
                moving = false;
                genOrders();
            }
        }

        if (transform.rotation.eulerAngles.y >= 90)
        {
            //if it stops turning right
            ordering = false;
            transform.position += new Vector3(0.5f, 0, 0);
            if (cloned == false)
            {
                Invoke("cloning", 2f);
                cloned = true;
            }
        }

        if (Input.GetKeyDown("c"))
        {
            Debug.Log("C was pressed");
            if (hasFood)
            {
                //not holding food
                Debug.Log("hasFood is TRUE");
                ordering = true;
                hasFood = false;
            }
            else
            {
                //holding food
                Debug.Log("hasFood is FALSE");
            }
        }
    }

    void cloning()
    {
        foreach (Transform child in frenchtoast.transform)
        {
            //makes everything in french toast GONE
            child.gameObject.SetActive(false);
        }
        //starts everythin
        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = startPos - new Vector3(0, 0, 10f);
        moving = true;
        cloned = false;
    }

    void genOrders()
    {
        randomNum = Random.Range(1, 21);

        if (randomNum == 1)
        {
            order COOKIE = new order("Cookie", false, false, true, false, false, false, this);
            COOKIE.DisplayName();
            price = 2;
            currentOrderPhoto.sprite = orderPhotos[0];
        }
        else if (randomNum == 2)
        {
            order COOKIE_LEMONADE = new order("Cookie Lemonade", false, true, true, false, false, false, this);
            COOKIE_LEMONADE.DisplayName();
            price = 3;
            currentOrderPhoto.sprite = orderPhotos[1];
        }
        else if (randomNum == 3)
        {
            order BREAD = new order("Bread", false, false, false, true, false, false, this);
            BREAD.DisplayName();
            price = 1;
            currentOrderPhoto.sprite = orderPhotos[2];
        }
        else if (randomNum == 4)
        {
            order BREAD_LEMONADE = new order("Bread Lemonade", false, false, true, true, false, false, this);
            BREAD_LEMONADE.DisplayName();
            price = 2;
            currentOrderPhoto.sprite = orderPhotos[3];
        }
        else if (randomNum == 5)
        {
            order BREAD_HAM = new order("Bread and Ham", false, false, false, true, true, false, this);
            BREAD_HAM.DisplayName();
            price = 2;
            currentOrderPhoto.sprite = orderPhotos[4];
        }
        else if (randomNum == 6)
        {
            order BREAD_HAM_LEMONADE = new order("Bread and Ham Lemonade", false, true, false, true, true, false, this);
            BREAD_HAM_LEMONADE.DisplayName();
            price = 3;
            currentOrderPhoto.sprite = orderPhotos[5];
        }
        else if (randomNum == 7)
        {
            order BREAD_OLIVE = new order("Bread and Olive", false, false, false, true, false, true, this);
            BREAD_OLIVE.DisplayName();
            price = 2;
            currentOrderPhoto.sprite = orderPhotos[6];
        }
        else if (randomNum == 8)
        {
            order BREAD_HAM_OLIVE = new order("Bread and Ham and Olive", false, false, false, true, true, true, this);
            BREAD_HAM_OLIVE.DisplayName();
            price = 3;
            currentOrderPhoto.sprite = orderPhotos[7];
        }
        else if (randomNum == 9)
        {
            order BREAD_HAM_OLIVE_LEMONADE = new order("Bread and Ham and Olive Lemonade", false, true, false, true, true, true, this);
            BREAD_HAM_OLIVE_LEMONADE.DisplayName();
            price = 4;
            currentOrderPhoto.sprite = orderPhotos[8];
        }
        else if (randomNum == 10)
        {
            order EGG = new order("Egg", true, false, false, false, false, false, this);
            EGG.DisplayName();
            price = 1;
            currentOrderPhoto.sprite = orderPhotos[9];
        }
        else if (randomNum == 11)
        {
            order EGG_LEMONADE = new order("Egg Lemonade", true, true, false, false, false, false, this);
            EGG_LEMONADE.DisplayName();
            price = 2;
            currentOrderPhoto.sprite = orderPhotos[10];
        }
        else if (randomNum == 12)
        {
            order EGG_OLIVE = new order("Egg and Olive", true, false, false, false, false, true, this);
            EGG_OLIVE.DisplayName();
            price = 2;
            currentOrderPhoto.sprite = orderPhotos[11];
        }
        else if (randomNum == 13)
        {
            order EGG_OLIVE_LEMONADE = new order("Egg and Olive Lemonade", true, true, false, false, false, true, this);
            EGG_OLIVE_LEMONADE.DisplayName();
            price = 3;
            currentOrderPhoto.sprite = orderPhotos[12];
        }
        else if (randomNum == 14)
        {
            order EGG_SANDWICH = new order("Egg Sandwich", true, false, false, true, false, false, this);
            EGG_SANDWICH.DisplayName();
            price = 4;
            currentOrderPhoto.sprite = orderPhotos[13];
        }
        else if (randomNum == 15)
        {
            order EGG_HAM_SANDWICH = new order("Egg and Ham Sandwich", true, false, false, true, true, false, this);
            EGG_HAM_SANDWICH.DisplayName();
            price = 3;
            currentOrderPhoto.sprite = orderPhotos[14];
        }
        else if (randomNum == 16)
        {
            order EGG_HAM_SANDWICH_LEMONADE = new order("Egg and Ham Sandwich Lemonade", true, true, false, true, true, false, this);
            EGG_HAM_SANDWICH_LEMONADE.DisplayName();
            price = 4;
            currentOrderPhoto.sprite = orderPhotos[15];
        }
        else if (randomNum == 17)
        {
            order EGG_OLIVE_SANDWICH = new order("Egg and Olive Sandwich", true, false, false, true, false, true, this);
            EGG_OLIVE_SANDWICH.DisplayName();
            price = 3;
            currentOrderPhoto.sprite = orderPhotos[16];
        }
        else if (randomNum == 18)
        {
            order EGG_OLIVE_SANDWICH_LEMONADE = new order("Egg and Olive Sandwich Lemonade", true, true, false, true, false, true, this);
            EGG_OLIVE_SANDWICH_LEMONADE.DisplayName();
            price = 4;
            currentOrderPhoto.sprite = orderPhotos[17];
        }
        else if (randomNum == 19)
        {
            order EGG_HAM_OLIVE_SANDWICH = new order("Egg and Ham and Olive Sandwich", true, false, false, true, true, true, this);
            EGG_HAM_OLIVE_SANDWICH.DisplayName();
            price = 5;
            currentOrderPhoto.sprite = orderPhotos[18];
        }
        else if (randomNum == 20)
        {
            order EGG_HAM_OLIVE_SANDWICH_LEMONADE = new order("Egg and Ham and Olive Sandwich Lemonade", true, true, false, true, true, true, this);
            EGG_HAM_OLIVE_SANDWICH_LEMONADE.DisplayName();
            price = 6;
            currentOrderPhoto.sprite = orderPhotos[19];
        }
    }
}


/*
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
    #endregion

    #region Variables
    public Vector3 startPos;
    public GameObject frenchtoast;
    public Text orderName;
    //private string currentOrderName;
    public bool moving = false;
    public bool ordering = false;
    public bool cloned = false;
    public int randomNum;
    public bool hasFood = false;
    public int price;
    public Image currentOrderPhoto;
    public Sprite[] orderPhotos;
    private string message = this.name;


    public AudioSource PuduCameBack;

    private order currentOrder;
    #endregion
    

    #region orderVars
    /*
    order COOKIE = new order("Cookie", false, false, true, false, false, false);
    order COOKIE_LEMONADE = new order("Cookie Lemonade", false, true, true, false, false, false);
    order BREAD = new order("Bread", false, false, false, true, false, false);
    order BREAD_LEMONADE = new order("Bread Lemonade", false, false, true, true, false, false);
    order BREAD_OLIVE = new order("Bread and Olive", false, false, false, true, false, true);
    order BREAD_HAM = new order("Bread and Ham", false, false, false, true, true, false);
    order BREAD_HAM_LEMONADE = new order("Bread and Ham Lemonade", false, true, false, true, true, false);
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
    */
//#endregion

#region Comments
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

#endregion

        /*
    
        void genOrders()
        {
            randomNum = Random.Range(1, 20);

            if (randomNum == 1)
            {
                order COOKIE = new order("Cookie", false, false, true, false, false, false);
                COOKIE.DisplayName();
                price = 2;
                currentOrderPhoto.sprite = orderPhotos[0];
            }
            else if (randomNum == 2)
            {
                order COOKIE_LEMONADE = new order("Cookie Lemonade", false, true, true, false, false, false);
                COOKIE_LEMONADE.DisplayName();
                price = 3;
                currentOrderPhoto.sprite = orderPhotos[1];
            }
            else if (randomNum == 3)
            {
                order BREAD = new order("Bread", false, false, false, true, false, false);
                BREAD.DisplayName();
                price = 1;
                currentOrderPhoto.sprite = orderPhotos[2];
            }
            else if (randomNum == 4)
            {
                order BREAD_LEMONADE = new order("Bread Lemonade", false, false, true, true, false, false);
                BREAD_LEMONADE.DisplayName();
                price = 2;
                currentOrderPhoto.sprite = orderPhotos[3];

            }
            else if (randomNum == 5)
            {
                order BREAD_HAM = new order("Bread and Ham", false, false, false, true, true, false);
                BREAD_HAM.DisplayName();
                price = 2;
                currentOrderPhoto.sprite = orderPhotos[4];
            }
            else if (randomNum == 6)
            {
                order BREAD_HAM_LEMONADE = new order("Bread and Ham Lemonade", false, true, false, true, true, false);
                BREAD_HAM_LEMONADE.DisplayName();
                price = 3;
                currentOrderPhoto.sprite = orderPhotos[5];
            }
            else if (randomNum == 7)
            {
                order BREAD_OLIVE = new order("Bread and Olive", false, false, false, true, false, true);
                BREAD_OLIVE.DisplayName();
                price = 2;
                currentOrderPhoto.sprite = orderPhotos[6];
            }
            else if (randomNum == 8)
            {
                order BREAD_HAM_OLIVE = new order("Bread and Ham and Olive", false, false, false, true, true, true);
                BREAD_HAM_OLIVE.DisplayName();
                price = 3;
                currentOrderPhoto.sprite = orderPhotos[7];
            }
            else if (randomNum == 9)
            {
                order BREAD_HAM_OLIVE_LEMONADE = new order("Bread and Ham and Olive Lemonade", false, true, false, true, true, true);
                BREAD_HAM_OLIVE_LEMONADE.DisplayName();
                price = 4;
                currentOrderPhoto.sprite = orderPhotos[8];
            }
            else if (randomNum == 10)
            {
                order EGG = new order("Egg", true, false, false, false, false, false);
                EGG.DisplayName();
                price = 1;
                currentOrderPhoto.sprite = orderPhotos[9];
            }
            else if (randomNum == 11)
            {
                order EGG_LEMONADE = new order("Egg Lemonade", true, true, false, false, false, false);
                EGG_LEMONADE.DisplayName();
                price = 2;
                currentOrderPhoto.sprite = orderPhotos[10];
            }
            else if (randomNum == 12)
            {
                order EGG_OLIVE = new order("Egg and Olive", true, false, false, false, false, true);
                EGG_OLIVE.DisplayName();
                price = 2;
                currentOrderPhoto.sprite = orderPhotos[11];
            }
            else if (randomNum == 13)
            {
                order EGG_OLIVE_LEMONADE = new order("Egg and Olive Lemonade", true, true, false, false, false, true);
                EGG_OLIVE_LEMONADE.DisplayName();
                price = 3;
                currentOrderPhoto.sprite = orderPhotos[12];
            }
            else if (randomNum == 14)
            {
                order EGG_SANDWICH = new order("Egg Sandwich", true, false, false, true, false, false);
                EGG_SANDWICH.DisplayName();
                price = 4;
                currentOrderPhoto.sprite = orderPhotos[13];
            }
            else if (randomNum == 15)
            {
                order EGG_HAM_SANDWICH = new order("Egg and Ham Sandwich", true, false, false, true, true, false);
                EGG_HAM_SANDWICH.DisplayName();
                price = 3;
                currentOrderPhoto.sprite = orderPhotos[14];
            }
            else if (randomNum == 16)
            {
                order EGG_HAM_SANDWICH_LEMONADE = new order("Egg and Ham Sandwich Lemonade", true, true, false, true, true, false);
                EGG_HAM_SANDWICH_LEMONADE.DisplayName();
                price = 4;
                currentOrderPhoto.sprite = orderPhotos[15];
            }
            else if (randomNum == 17)
            {
                order EGG_OLIVE_SANDWICH = new order("Egg and Olive Sandwich", true, false, false, true, false, true);
                EGG_OLIVE_SANDWICH.DisplayName();
                price = 3;
                currentOrderPhoto.sprite = orderPhotos[16];
            }
            else if (randomNum == 18)
            {
                order EGG_OLIVE_SANDWICH_LEMONADE = new order("Egg and Olive Sandwich Lemonade", true, true, false, true, false, true);
                EGG_OLIVE_SANDWICH_LEMONADE.DisplayName();
                price = 4;
                currentOrderPhoto.sprite = orderPhotos[17];
            }
            else if (randomNum == 19)
            {
                order EGG_HAM_OLIVE_SANDWICH = new order("Egg and Ham and Olive Sandwich", true, false, false, true, true, true);
                EGG_HAM_OLIVE_SANDWICH.DisplayName();
                price = 5;
                currentOrderPhoto.sprite = orderPhotos[18];
            }
            else if (randomNum == 20)
            {
                order EGG_HAM_OLIVE_SANDWICH_LEMONADE = new order("Egg and Ham and Olive Sandwich Lemonade", true, true, false, true, true, true);
                EGG_HAM_OLIVE_SANDWICH_LEMONADE.DisplayName();
                price = 6;
                currentOrderPhoto.sprite = orderPhotos[19];
            }
        }
    }
    
*/
    //new GenOrders
    

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

