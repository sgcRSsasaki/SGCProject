using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRight : MonoBehaviour
{
    public EnemyController controller;
    public Sprite sprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        controller.SpeedSetter(-0.005f);
        controller.SpriteSetter(sprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
