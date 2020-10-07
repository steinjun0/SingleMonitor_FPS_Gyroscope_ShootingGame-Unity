using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    #region Instance
    private static GyroManager instance;
    public static GyroManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GyroManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned HyroManager", typeof(GyroManager)).GetComponent<GyroManager>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion


    [Header("Logic")]
    private Gyroscope gyro;
    private Quaternion rotation;
    private float rotation_hor;
    private float rotation_ver;
    private float temp_hor =0;
    private float temp_ver=0;
    private bool gyroActive;

    public void EnableGyro()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
        gyroActive = gyro.enabled;

    }
    private void Update()
    {
        if(gyroActive)
        {
            rotation = gyro.attitude;
            rotation_hor = temp_hor - gyro.attitude.eulerAngles.x;
            rotation_ver = temp_ver - gyro.attitude.eulerAngles.y;
            temp_hor = gyro.attitude.eulerAngles.x;
            temp_ver = gyro.attitude.eulerAngles.y;
        }
    }

    public Quaternion GetGyroRotation()
    {
        return rotation;
    }

    public float GetGyroRotationHor()
    {
        return rotation_hor;
    }

    public float GetGyroRotationVer()
    {
        return rotation_ver;
    }
}
