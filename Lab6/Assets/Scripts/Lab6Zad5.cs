using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab6Zad5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("KOLIZJA");
        }
    }
}
