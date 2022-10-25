using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class zad4 : MonoBehaviour  
{  
    Vector3 v;  
    public int speed = 8;
    void Start()  
    {  
          
    }  
   
    void FixedUpdate()  
    {  
  
        v = transform.localPosition;  
        v.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;  
        v.z += Input.GetAxis("Vertical") * Time.deltaTime * speed;  
        v.y += Input.GetAxis("Jump") * Time.deltaTime * speed;  
        
        transform.localPosition = v;  
    }  
}  