using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Move : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Mathf.Clamp(Ball.singleton.rb.velocity.y, -PlayerManager.playerMoveSpeed, PlayerManager.playerMoveSpeed) * Time.deltaTime;
        Vector2 moveVec = new Vector2(0.0f, move);

        if (TwoPlayerTurns.AITurn)
        {
            rb.velocity = moveVec;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TwoPlayerTurns.BALL_ID)
        {
            TwoPlayerTurns.AITurn = false;
            Debug.Log("PLAYER TURN");
        }
    }
}
