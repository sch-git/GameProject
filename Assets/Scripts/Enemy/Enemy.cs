using UnityEngine;

namespace Enemy
{
    // 抽象敌人类
    public abstract class Enemy: MonoBehaviour
    {
        public GameObject bloodEffect;
        public int health;
        public int damage;
        public float flashTime = 0.1f;
        
        private Color _originalColor;
        private SpriteRenderer _spriteRenderer;
        protected void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalColor = _spriteRenderer.color;
        }

        protected void Update()
        {
            if (health <= 0)
            {
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
    }
}