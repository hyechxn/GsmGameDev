using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float cameraMoveScale;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * cameraMoveScale);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
