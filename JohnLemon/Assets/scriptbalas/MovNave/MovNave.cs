using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovNave : MonoBehaviour
{
    [SerializeField]
    float speedRotationVertical = 10f;

    [SerializeField]
    float speedRotationHorizontal = 10f;

    [SerializeField]
    float speed = 0.0f;




    void Update()
    {
        float rotationX = Input.GetAxis("Vertical") * speedRotationVertical * Time.deltaTime;

        float rotationY = Input.GetAxis("Horizontal") * speedRotationHorizontal * Time.deltaTime;

        transform.position += (transform.forward * Time.deltaTime * speed);

        transform.Rotate(rotationX, 0f, 0f, Space.Self);
    }

}
