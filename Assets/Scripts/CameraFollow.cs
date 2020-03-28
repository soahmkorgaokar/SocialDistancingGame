using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float height = 10.0f;
    public float size = 5.0f;
    public bool onlySetSizeOnce = true;

    void Start()
    {
        Camera.main.transform.position = new Vector3(target.position.x, target.position.y + height, target.position.z);
        Camera.main.orthographicSize = size;
    }

    void Update()
    {
        Camera.main.transform.position = new Vector3(target.position.x, target.position.y + height, target.position.z);
        if (!onlySetSizeOnce)
        {
            Camera.main.orthographicSize = size;
        }
    }
}
