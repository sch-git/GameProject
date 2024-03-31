using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // 攻击力
    public int damage = 1;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // 碰撞检测
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<Enemy.Enemy>();
            enemy.TakeDamage(damage);
        }
    }
}
