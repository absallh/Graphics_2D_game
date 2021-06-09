using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera11 : MonoBehaviour
{
    private Transform target;
    private Vector3 offset;

    public float smoothSpeed = 0.15f;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("PLAYER").transform;
        offset = transform.position - target.position;
    }
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}