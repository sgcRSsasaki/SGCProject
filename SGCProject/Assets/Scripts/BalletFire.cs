using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalletFire : MonoBehaviour
{
    [SerializeField] 
    GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) //���}�E�X�{�^���������ꂽ��
        {
            Instantiate(Bullet, transform.position, transform.rotation);
        }
    }
}
