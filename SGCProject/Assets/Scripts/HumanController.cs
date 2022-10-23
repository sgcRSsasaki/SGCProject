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
    private int count = 0;
    private float t;
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

        //?¿½?¿½?¿½Ú“ï¿½
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        Vector2 pos = gameObject.transform.position;
        pos += (movement * (grounded ? speed : speed2) * Time.deltaTime);

        
        float playerPos = transform.position.y;
        float targetPos = 200f;



        //?¿½W?¿½?¿½?¿½?¿½?¿½v
        if (Input.GetKey("space"))
        {
            if (grounded)
            {
                count = 0;
                pos.y = Mathf.Lerp(playerPos, targetPos, 0.5f * Time.deltaTime);
                ++count;
            }
            else if(count < 2) 
            {
                pos.y = Mathf.Lerp(playerPos, targetPos, 0.5f * Time.deltaTime);
                ++count;
            }
            

        }


        gameObject.transform.position = pos;
    }
}
