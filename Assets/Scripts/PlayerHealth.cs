using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    public int health = 10;
    public int number;
    public float blinkTime;
    [Header("Health UI")] 
    public GameObject healthImageObj;

    private Image _healthImageComponent;
    private int _maxHealth;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _animator = gameObject.GetComponent<Animator>();
        _healthImageComponent = healthImageObj.GetComponent<Image>();
        _maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 玩家受伤
    public void DamagePlayer(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            _animator.SetTrigger("Die");
        }else if (damage > 0)
        {
            BlinkPlayer(number, blinkTime);
        }
        // ui 血条展示逻辑
        _healthImageComponent.fillAmount = health / (float)_maxHealth;
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
    }

    void BlinkPlayer(int number, float time)
    {
        StartCoroutine(DoBlink(number, time));
    }

    IEnumerator DoBlink(int number, float time)
    {
        for (int i = 0; i < number * 2; i++)
        {
            _spriteRenderer.enabled = !_spriteRenderer.enabled;
            yield return new WaitForSeconds(time);
        }

        _spriteRenderer.enabled = true;
    }
}
