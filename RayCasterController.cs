using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasterController : MonoBehaviour
{
    public float shootingRange = 5.0f;
    Ray ray;
    void Start()
    {
        ray = new Ray(transform.position, transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;

        Debug.DrawRay(ray.origin, ray.direction * shootingRange, Color.red);
    }
}