using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Heart : MonoBehaviour
{
    [SerializeField]
    Image heart;
    [SerializeField]
    Sprite[] sprites;

    public void HeartSetter(int hp)
    {
        heart.sprite = sprites[hp];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
