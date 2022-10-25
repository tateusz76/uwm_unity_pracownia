using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour


{
    public float speed = 8;
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
        v = v.normalized * speed * Time.deltaTime;
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter (Collider Player)
 {
     if (Player.tag == "Turn")
     {
         transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
     }
 }
}
