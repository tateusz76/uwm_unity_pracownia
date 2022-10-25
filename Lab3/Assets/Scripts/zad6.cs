using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad6 : MonoBehaviour
{
    Transform target;
    float smoothTime = 0.3f;
    float yVelocity = 0.0f;

    public float minimum = -1.0F;
    public float maximum =  1.0F;
    static float t = 0.0f;

    void Update()
    {
        float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);

        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0);

    }
}