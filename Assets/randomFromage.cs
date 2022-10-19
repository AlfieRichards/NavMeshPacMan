using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomFromage : MonoBehaviour
{
    public Vector3 rightPos;
    public Vector3 leftPos;

    public float speed = 1.0f;
 
    void Update() 
    {
        transform.position = Vector3.Lerp (rightPos, leftPos, Mathf.PingPong(Time.time*speed, 1.0f));
    }
}
