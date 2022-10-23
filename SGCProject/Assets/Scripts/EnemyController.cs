using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer renderer;
    float speed = -0.005f;
    public void SpeedSetter(float speed)
    {
        this.speed = speed;
    }

    public void SpriteSetter(Sprite sprite)
    {
        renderer.sprite = sprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);
    }
}
