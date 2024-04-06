
using System;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject player;
    private bool _canDown;

    private CompositeCollider2D _compositeCollider2D;
    private BoxCollider2D _boxCollider2D;

    private void Start()
    {
        _compositeCollider2D = GetComponent<CompositeCollider2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canDown = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _canDown = false;
            Invoke("ResetIsTrigger",0.1f);
        }
    }

    public bool CanDown()
    {
        return _canDown;
    }

    void ResetIsTrigger()
    {
        SetTriggerTure(false);
    }

    public void SetTriggerTure()
    {
        SetTriggerTure(true);
    }
    void SetTriggerTure(bool isTrigger)
    {
        if (_compositeCollider2D != null)
        {
            _compositeCollider2D.isTrigger = isTrigger;
        }

        if (_boxCollider2D != null)
        {
            _boxCollider2D.isTrigger = isTrigger;
        }
    }
}
