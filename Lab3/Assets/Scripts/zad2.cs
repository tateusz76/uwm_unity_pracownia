using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad2 : MonoBehaviour

    
{
    public float speed = 4;
    public Rigidbody rb;
    public int kierunek = 1;
    Vector3 v = new Vector3(10, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < 0)
        {
            kierunek = 1;
        }
        else if (transform.position.x > 10)
        {
            kierunek = -1;
        }

        v = v.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + v * kierunek);
        


    }
}
