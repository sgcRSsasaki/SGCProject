using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPanel : MonoBehaviour
{
    private void Start()
    {
        confirmationPanel.SetActive(false);
    }

    void Update()
    {
        //Esc�������ꂽ��
        if (Input.GetKey(KeyCode.Escape))
        {
            confirmationPanel.SetActive(true);
        }
    }
}
