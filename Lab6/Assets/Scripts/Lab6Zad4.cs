using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab6Zad4 : MonoBehaviour
{

    public GameObject gracz;
    private Vector3 playerBounce;
    public float bounceForce = 5.0f;
    public float gravityValue = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("KOLIZJA");
            playerBounce.y += Mathf.Sqrt(bounceForce * -10.0f * gravityValue);
            gracz.GetComponent<CharacterController>().Move(playerBounce * Time.deltaTime);
        }
    }
}

