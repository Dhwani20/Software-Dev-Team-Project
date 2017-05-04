using UnityEngine;
using System.Collections;

public class GyroCamera : MonoBehavior
{
    private Gyroscope gyro;
    private bool gyroSupported;
    private Quarternion rotfix;

    [SerializedField]
    private transform worldObj;
    private float startY;


    void Start ()
    {
        gyroSupported = SystemInfo.supportedGyroscope;

        GameObject camParent = new GameObject("camParent");
        camParent.transform.position = transform.position;
        transform.parent = camParent.transform;



        if (gyroSupported)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            camParent.transform.rotation = Quarternion.Euler(90f, 10f, 0f);
            rotfix = new Quarternion(0, 0, 1, 0);

        }
    }

    void Update()
    {
        if (gyroSupported && startY == 0)
        {
            ResetGyroRotation();

        }
        transform.rotation = gyro.attitude * rotfix;
    }

    void ResetGyroRotation()
    {
        startY = transform.eulerAngles.y;
        worldObj.rotation = Quarternion.Euler(0f, startY, 0f);

    }

}
