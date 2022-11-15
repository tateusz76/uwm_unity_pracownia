using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab6Zad2 : MonoBehaviour
{
    private float opened;
    private float closed;
    public float movementSpeed = 5f;

    public GameObject door;
     
    bool isOpening;
     
    // Start is called before the first frame update
    void Start()
    {
        isOpening = false;
        opened = door.transform.position.x + 4.0f;
        closed = door.transform.position.x;
    }
 
    // Update is called once per frame
    void Update()
    {
        if(isOpening){
            if(door.transform.position.x < opened){
                door.transform.Translate(movementSpeed * Time.deltaTime, 0f, 0f);
            }
        }else{
            if(door.transform.position.x > closed){
                door.transform.Translate(-movementSpeed * Time.deltaTime, 0f, 0f);
            }
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Drzwi sie otwierają");
            isOpening = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Drzwi sie zamykają");
            isOpening = false;
        }
    }
}