using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public float speed;
    public float jump;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //‰¡ˆÚ“®

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb.AddForce(movement * speed);

        //ƒWƒƒƒ“ƒv
        if (Input.GetKeyDown("space"))
        {
            // ã•ûŒü‚É—Í‚ğ‰Á‚¦‚é
            rb.AddForce(Vector2.up * jump);
        }
    }
}
