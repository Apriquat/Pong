using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector2(xMove * moveSpeed, yMove * moveSpeed);

        transform.position += move * Time.deltaTime;
    }
}
