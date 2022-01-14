using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed;
    private Rigidbody2D rb;
    private Vector2 startPos;

    // Start is called before the first frame update
    private void Awake()
    {
        startPos = transform.position;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameEvents.current.OnGameReset += ResetPlayer;
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

    void ResetPlayer()
    {
        transform.position = startPos;
    }
}
