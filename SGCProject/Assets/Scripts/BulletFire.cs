using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public GameObject Bullet;
    private float timeBetweenShot = 0.35f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (Input.GetMouseButton(0) && timer > timeBetweenShot)
		{
            timer = 0.0f;
            Instantiate(Bullet, transform.position, transform.rotation);
		}
    }
}
