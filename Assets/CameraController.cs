using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Transform follow_target;
    [SerializeField] float distance = 7.5f;
    [SerializeField] float rotation_speed = 2;
    [SerializeField] float min_vertical_angle = 0;
    [SerializeField] float max_vertical_angle = 90;

    private Vector2 rotation;

    // Update is called once per frame
    void Update()
    {
        rotation += new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * rotation_speed;
        rotation.x = Mathf.Clamp(rotation.x,min_vertical_angle,max_vertical_angle);

        var target_rotation = Quaternion.Euler(rotation);
        transform.position = follow_target.position - target_rotation * new Vector3(0f, 0f, distance);
        transform.rotation = target_rotation;
    }
}
