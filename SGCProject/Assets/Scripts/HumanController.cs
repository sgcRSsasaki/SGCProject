using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer renderer;

    enum State
    {
        Normal,
        Test,

    }
    [SerializeField]
    Sprite[] sprites;
    public float speed;
    public float jump;
    public LayerMask groundlayer;
    private Rigidbody2D rb;
    bool damage = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!damage)
            {
                damage = true;
                Debug.Log("‚Ò‚¦‚ñ");
                StartCoroutine(SetSprite(sprites[(int)State.Test], 1.0f, () => { damage = false;  }));
            }
        }
    }
    private IEnumerator SetSprite(Sprite sprite, float time, Action finish)
    {
        var before = renderer.sprite;
        renderer.sprite = sprite;

        // 1•b‘Ò‚Â
        yield return new WaitForSeconds(time);

        renderer.sprite = before;

        finish();
        
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
        pos += (movement * speed * Time.deltaTime);
        
        gameObject.transform.position = pos;

        //?¿½W?¿½?¿½?¿½?¿½?¿½v
        if (Input.GetKeyDown("space"))
        {
            if (grounded)
            {
                // ?¿½?¿½?¿½?¿½?¿½?¿½É—Í‚ï¿½?¿½?¿½?¿½?¿½?¿½?¿½
                rb.AddForce(Vector2.up * jump);
            }
        }
    }
}
