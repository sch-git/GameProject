using System;
using UnityEngine;

namespace Enemy
{
    // 抽象敌人类
    public abstract class Enemy: MonoBehaviour
    {

        [Header("基础属性")]
        public int health;
        public int damage;
        public GameObject bloodEffect;
        public GameObject dropCoin;
        public float flashTime = 0.1f;
        
        private Color _originalColor;
        private SpriteRenderer _spriteRenderer;
        private PlayerHealth _playerHealth;
        protected void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalColor = _spriteRenderer.color;
            _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }

        protected void Update()
        {
            if (health <= 0)
            {
                Instantiate(dropCoin, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        // 受击处理
        public void TakeDamage(int val)
        {
            health -= val;
            _spriteRenderer.color = Color.red;
            Invoke(nameof(ResetColor),flashTime);
            // 实例化粒子系统
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
        }
        
        // 重置 color
        void ResetColor()
        {
            _spriteRenderer.color = _originalColor;
        }
        

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
            {
                if (_playerHealth!=null)
                {
                    _playerHealth.DamagePlayer(damage);
                }
            }
        }
    }
}