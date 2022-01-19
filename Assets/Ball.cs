using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public static Ball singleton;

    [SerializeField] private float ballMoveSpeed;
    public Rigidbody2D rb;
    private Vector2 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        singleton = this;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(ballMoveSpeed, 0f);
        lastVelocity = rb.velocity;

        GameEvents.current.OnGameReset += ResetBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 newVelocity;
        newVelocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
        newVelocity.y += collision.collider.attachedRigidbody.velocity.y / 3;
        //newVelocity.x = -lastVelocity.x;
        //newVelocity.y = (lastVelocity.y / 2 + collision.collider.attachedRigidbody.velocity.y / 3);
        rb.velocity = newVelocity;

        lastVelocity = newVelocity;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.ResetGame();
    }

    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        rb.transform.position = Vector2.zero;

        StartCoroutine("StartBall");
    }

    IEnumerator StartBall()
    {
        yield return new WaitForSeconds(3);
        rb.velocity = new Vector2(ballMoveSpeed, 0f);
    }
}
