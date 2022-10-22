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
        //Esc‚ª‰Ÿ‚³‚ê‚½Žž
        if (Input.GetKey(KeyCode.Escape))
        {
            confirmationPanel.SetActive(true);
        }
    }
}
