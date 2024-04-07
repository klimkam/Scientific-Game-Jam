using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    Camera m_Camera;
    [SerializeField]
    GameObject m_player;
    [SerializeField]
    float lookSpeed = 1.0f;
    [SerializeField]
    float XUpRotationClamp = 5f;
    [SerializeField]
    float XDownRotationClamp = -45f;

    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";

    private void Update()
    {
        rotation.x += Input.GetAxis(xAxis) * lookSpeed;
        rotation.y += -Input.GetAxis(yAxis) * lookSpeed;
        rotation.y = Mathf.Clamp(rotation.y, XDownRotationClamp, XUpRotationClamp);

        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.rotation = Quaternion.Euler(rotation.y, rotation.x, 0);


        /*        transform.Rotate(Vector3.up * rotation.x);*/
    }
}
