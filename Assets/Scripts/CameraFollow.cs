using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    [SerializeField] public float height = -10f;
    public float followSpeed = 2f;
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = new Vector3(target.position.x , target.position.y, height);
        transform.position = Vector3.Slerp(transform.position, newpos, followSpeed);
    }
}
