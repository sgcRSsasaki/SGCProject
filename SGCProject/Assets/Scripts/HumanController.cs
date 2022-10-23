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
        //â°à⁄ìÆ

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);
        Debug.Log(moveHorizontal);

        rb.AddForce(movement * speed);

        //ÉWÉÉÉìÉv
        if (Input.GetKeyDown("space") && !isJumping)
        {
            // è„ï˚å¸Ç…óÕÇâ¡Ç¶ÇÈ
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
