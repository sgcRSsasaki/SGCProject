using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public float speed;
    public float speed2;
    public float jump;
    public LayerMask groundlayer;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        bool grounded = Physics2D.Linecast(transform.position,
                                transform.position - transform.up * 1.5f,
                                groundlayer);

        //?��?��?��ړ�
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        Vector2 pos = gameObject.transform.position;
        pos += (movement * (grounded ? speed : speed2) * Time.deltaTime);
        
        gameObject.transform.position = pos;

        //?��W?��?��?��?��?��v
        if (Input.GetKeyDown("space"))
        {
            if (grounded)
            {
                // ?��?��?��?��?��?��ɗ͂�?��?��?��?��?��?��
                rb.AddForce(Vector2.up * jump);
            }
        }
    }
}
