using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float height = 10.0f;

    void Start()
    {
        Camera.main.transform.position = new Vector3(target.position.x, target.position.y + height, target.position.z);
    }

    void Update()
    {
        Camera.main.transform.position = new Vector3(target.position.x, target.position.y + height, target.position.z);
    }
}
