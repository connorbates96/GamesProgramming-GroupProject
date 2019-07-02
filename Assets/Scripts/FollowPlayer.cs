using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform followPlayer;
    private Transform cameraTransform;

    public Vector3 playerOffset;

    public float MoveSpeed = 400f;
    // Start is called before the first frame update
    private void Start()
    {
        cameraTransform = transform;
    }

    // Update is called once per frame
    public void SetTarget(Transform newTransformTarget)
    {
        followPlayer = newTransformTarget;
    }

    private void LateUpdate()
    {
        if (followPlayer!= null)
        {
            //interpolate between two vectors
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, followPlayer.position + playerOffset, MoveSpeed * Time.deltaTime);
        }
    }
}
