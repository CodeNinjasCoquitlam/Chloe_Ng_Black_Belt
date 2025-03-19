using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orders : MonoBehaviour
{
    //public string[] = new string[] {"Egg Sandwich", "Milk",};
    public bool order = false;


    void Start()
    {

    }

    void Update()
    {
        if(order == true)
        {
            transform.Rotate(Vector3.up * 60 * Time.deltaTime);
        }
        
        if (transform.rotation.eulerAngles.y >= 90)
        {
            order = false;
            transform.position += new Vector3(1.5f, 0, 0);
            Invoke("cloning", 1.0f);
        }

    }

    void cloning()
    {
        Instantiate()
    }
}
