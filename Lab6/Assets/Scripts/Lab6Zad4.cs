using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab6Zad4 : MonoBehaviour //rozpoczęte nie skończone
{
    public GameObject player;
    Vector3 direction;
    public float force = 5f;

    // Update is called once per frame
    void Update()
    {
        direction = transform.TransformDirection(Vector3.up * force);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Wybija");
            player = other.gameObject;
            player.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
        }
    }
}
