using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public int health = 10;
    public int number;
    public float blinkTime;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
