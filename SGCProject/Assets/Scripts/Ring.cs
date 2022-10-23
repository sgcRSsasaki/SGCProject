using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    float speed = -0.02f;
    private Vector3 _initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.transform.position = _initialPosition;
    }
}
