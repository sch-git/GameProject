using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatformController : MonoBehaviour
{

    public Transform targetTransform;

    public float moveSpeed;

    private Vector3 _oriPosition;
    private Transform _playerTransformParent;
    void Start()
    {
        var position = transform.position;
        _oriPosition = new Vector2(position.x,position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, targetTransform.position)>Mathf.Epsilon)
        {
            // 向目标位置移动
            transform.position =
                Vector2.MoveTowards(transform.position, targetTransform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            // 反转当前位置和原位置
            var position = targetTransform.position;
            var tmpPosition = new Vector2(position.x,position.y);
            targetTransform.position = new Vector2(_oriPosition.x, _oriPosition.y);
            _oriPosition = tmpPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            _playerTransformParent = other.transform.parent;
            other.transform.parent = gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.parent = _playerTransformParent;
    }
}
