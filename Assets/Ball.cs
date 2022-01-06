using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float ballMoveSpeed;
    [SerializeField] private Vector2 move;
    private Rigidbody2D rb;
    private Vector2 lastVelocity;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        move = Vector2.right * ballMoveSpeed;
        rb.velocity = move;
        lastVelocity = move;
    }

    private void OnTriggerEnter(Collider other)
    {
        move = Vector2.Reflect(lastVelocity, other.normal);
        Debug.Log(other.normal);
        lastVelocity = move;
    }
    private void OnTriggerEnter(Collision collision)
    {

    }
}
