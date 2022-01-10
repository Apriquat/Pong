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
        float move = Input.GetAxisRaw("Vertical");
        Vector2 moveVec = new Vector2(0, move * playerMoveSpeed);

        rb.velocity = moveVec;

        Debug.Log(moveVec);
    }
}
