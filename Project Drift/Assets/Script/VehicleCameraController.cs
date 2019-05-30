using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCameraController : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    public float FollowSpeed = 10;
    public float LookSpeed = 75;

    public void LookAtTarget()
    {
        Vector3 LookDir = Target.position - transform.position;
        Quaternion Rot = Quaternion.LookRotation(LookDir, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, Rot, LookSpeed * Time.deltaTime);
    }

    public void MoveToTarget()
    {
        Vector3 TargetPos = Target.position +
            Target.forward * Offset.z +
            Target.right * Offset.x +
            Target.up * Offset.y;
        transform.position = Vector3.Lerp(transform.position, TargetPos, FollowSpeed * Time.deltaTime);
    }

    public void LateUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }

}
