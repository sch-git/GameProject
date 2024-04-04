using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikaController : MonoBehaviour
{
    public PlayerHealth playerHealth;
    // 伤害剩余冷却时间
    private float _damageCd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 地刺碰撞检测
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (_damageCd <= 0)
            {
                playerHealth.DamagePlayer(1);
                _damageCd = 0.5f;
            }
            else
            {
                _damageCd -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _damageCd = 0;
    }
}
