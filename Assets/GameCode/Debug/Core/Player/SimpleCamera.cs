using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    public Transform CurrentTarget;

    public void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, CurrentTarget.position, Time.fixedDeltaTime * 5);
    }
}
