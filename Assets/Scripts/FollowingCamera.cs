using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    [Range(0, 1)]
    [SerializeField] private float smoothTime;

    [Header("Limits")]
    [SerializeField] private Vector2 xLimit; // x min value - y max value
    [SerializeField] private Vector2 yLimit;

    

    // Update is called once per frame
    void Update()
    {
        Vector3 target = playerPos.position + offset;
        target = new Vector3(Mathf.Clamp(target.x, xLimit.x, xLimit.y), Mathf.Clamp(target.y, yLimit.x, yLimit.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);
    }
}
