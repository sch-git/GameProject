using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sign : MonoBehaviour
{
    public GameObject signDialogBox;

    public TextMeshProUGUI textUI;

    private bool _canSign;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canSign)
        {
            textUI.text = "Hello, World!! Welcome To MyWorld";
            signDialogBox.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            _canSign = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            _canSign = false;
            signDialogBox.SetActive(false);
        }
    }
}
