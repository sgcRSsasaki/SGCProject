using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleLogo : MonoBehaviour
{
    public Text Ttext; //点滅させたいTextの変数
    float a_color; //透明度の変数
    bool flag_G; //上限の変数
    // Use this for initialization
    void Start()
    {
        a_color = 0;
    }
    // Update is called once per frame
    void Update()
    {
        //テキストの透明度を変更する
        Ttext.color = new Color(0, 0, 0, a_color);
        if (flag_G)
            a_color -= Time.deltaTime;
        else
            a_color += Time.deltaTime;
        if (a_color < 0)
        {
            a_color = 0;
            flag_G = false;
        }
        else if (a_color > 1)
        {
            a_color = 1;
            flag_G = true;
        }
    }
}