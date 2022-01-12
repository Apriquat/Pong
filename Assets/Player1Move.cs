using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        Vector2 moveVec = new Vector2(0, move * PlayerManager.playerMoveSpeed);

        rb.velocity = moveVec;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TwoPlayerTurns.BALL_ID)
        {
            TwoPlayerTurns.AITurn = true;
            Debug.Log("AI TURN");
        }
    }
}
