using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour, IRotate
{

    [SerializeField] private float rotationSpeed;
    public float RotationSpeed => rotationSpeed;

    public Quaternion GetRotation(Transform currrentTransform)
    {
        Vector2 newPos = Player.instance.transform.position - currrentTransform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        return Quaternion.Lerp(currrentTransform.rotation,
            Quaternion.Euler(0, 0, rotZ + 90f), rotationSpeed * Time.deltaTime);
    }

    public void Rotate()
    {
        transform.rotation = GetRotation(transform);
    }
}
