using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    private float H_Input;
    private float V_Input;
    private float S_Angle;

    [Header("Wheel Coliders")]
    public WheelCollider FrontWheelL; //Formatted across two lines due to unity's header  system.
    public WheelCollider FrontWheelR;
    public WheelCollider[] MidWheels;
    public WheelCollider BackWheelL, BackWheelR;
    [Space(5)]


    [Header("Wheel transforms")]
    public Transform FrontWheelLTransform; //Same issue with unity's header system, needs to be split across two lines.
    public Transform FrontWheelRTransform;
    public Transform[] MidWheelsTransform;
    public Transform BackWheelLTransform, BackWheelRTransform;

    [Header("Vehicle settings")]
    public float MaxSteeringAngle = 30;
    public float MotorForce = 60;
    public enum wheelDrive { Fwd, Awd, Rwd };
    public wheelDrive WheelDrive;

    public void GetInput()
    {
        H_Input = Input.GetAxis("Horizontal");
        V_Input = Input.GetAxis("Vertical");
    }

    private void UpdateSteering()
    {
        S_Angle = MaxSteeringAngle * H_Input;
        FrontWheelL.steerAngle = S_Angle;
        FrontWheelR.steerAngle = S_Angle;
    }

    private void Acel()
    {
        if (WheelDrive == wheelDrive.Fwd)
        {
            FrontWheelL.motorTorque = V_Input * MotorForce;
            FrontWheelR.motorTorque = V_Input * MotorForce;
        }
        else if (WheelDrive == wheelDrive.Awd)
        {
            FrontWheelL.motorTorque = V_Input * MotorForce;
            FrontWheelR.motorTorque = V_Input * MotorForce;
            foreach (WheelCollider MidWheel in MidWheels)
            {
                MidWheel.motorTorque = V_Input * MotorForce;
            }
            BackWheelL.motorTorque = V_Input * MotorForce;
            BackWheelR.motorTorque = V_Input * MotorForce;
        }
        else if (WheelDrive == wheelDrive.Rwd)
        {
            BackWheelL.motorTorque = V_Input * MotorForce;
            BackWheelR.motorTorque = V_Input * MotorForce;
        }
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(FrontWheelL, FrontWheelLTransform);
        UpdateWheelPos(FrontWheelR, FrontWheelRTransform);
        for (int i = 0; i != MidWheelsTransform.Length; i++)
        {
            UpdateWheelPos(MidWheels[i], MidWheelsTransform[i]);
        }
        UpdateWheelPos(BackWheelL, BackWheelLTransform);
        UpdateWheelPos(BackWheelR, BackWheelRTransform);
    }

    private void UpdateWheelPos(WheelCollider collider, Transform transform)
    {
        Vector3 Pos = transform.position;
        Quaternion quat = transform.rotation;

        collider.GetWorldPose(out Pos, out quat);

        transform.position = Pos;
        transform.rotation = quat;
    }

    void FixedUpdate()
    {
        GetInput();
        UpdateSteering();
        Acel();
        UpdateWheels();
    }
}
