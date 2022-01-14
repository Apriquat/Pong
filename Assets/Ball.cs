using System.Collections;
using System.Collections.Generic;
using UnityEngine

public class Ball : MonoBehaviour
{

    [SerializeField] private float ballMoveSpeed;
    public static Rigidbody2D rb;
    private Vector2 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
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

    public static void ResetBall()
    {
        rb.velocity = Vector2.zero;
        rb.transform.position = Vector2.zero;

        StartCoroutine();
    }

    IEnumerator StartBall()
    {
        yield return new WaitForSeconds(3);
        rb.velocity = new Vector2(ballMoveSpeed, 0f);
    }
}
