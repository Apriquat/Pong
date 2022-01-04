using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSensitivity;

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector2(xMove * moveSpeed, yMove * moveSpeed);

        transform.position += move * Time.deltaTime;

        bool rotLeft = Input.GetKey(KeyCode.Q);
        bool rotRight = Input.GetKey(KeyCode.E);

        if (rotLeft)
        {
            transform.Rotate(new Vector3(0, 0, rotationSensitivity));
        }
        else if (rotRight)
        {
            transform.Rotate(new Vector3(0, 0, -rotationSensitivity));
        }
    }
}
