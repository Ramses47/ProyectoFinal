using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour
{
    public float rotationLimit, rotationSpeed;

    private float originalVrotation, yRotation;
    private int orientation;
    // Start is called before the first frame update
    void Start()
    {
        originalVrotation = transform.localEulerAngles.y;
        yRotation = transform.localEulerAngles.y;
        orientation = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        if ((transform.localEulerAngles.y <= originalVrotation - rotationLimit) || (transform.localEulerAngles.y >= originalVrotation + rotationLimit))
        {

            ChangeRotation();
        }
        yRotation += rotationSpeed * orientation * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, yRotation, transform.localEulerAngles.z);
    }

    void ChangeRotation()
    {
        orientation *= -1;
    }
}
