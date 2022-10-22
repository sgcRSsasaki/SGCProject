using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPanel : MonoBehaviour
{

    public GameObject confirmationPanel1;
    public GameObject confirmationPanel2;

    private void Start()
    {
        confirmationPanel2.SetActive(false);
    }

    public void Event()
    {
        confirmationPanel1.SetActive(false);
        confirmationPanel2.SetActive(true);
    }
}
