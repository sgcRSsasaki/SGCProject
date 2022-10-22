using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public float speed;
    public float jump;
    private Rigidbody2D rb;
    private bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //横移動

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);
        Debug.Log(moveHorizontal);

        rb.AddForce(movement * speed);

        //ジャンプ
        if (Input.GetKeyDown("space") && !isJumping)
        {
            // 上方向に力を加える
            rb.AddForce(Vector2.up * jump);
            isJumping = true;
        }
        Debug.Log(isJumping);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
