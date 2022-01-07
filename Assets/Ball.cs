using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float ballMoveSpeed;
    private SpriteRenderer spriteRenderer;
    public static Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        move = Vector3.right;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        transform.position += move * ballMoveSpeed * Time.deltaTime;
    }
}
