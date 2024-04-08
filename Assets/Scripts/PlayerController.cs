
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移动配置")]
    public float moveSpeed = 1f;

    public float jumpSpeed = 1f;
    public float doubleJumpSpeed = 1f;

    private PlatformController _platformController;
    private LadderController _ladderController;
    

    private bool _canDoubleJump = false;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private BoxCollider2D _boxCollider2D;

    private bool isGround;
    private bool isClimb;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Run();
        CheckGround();
        Jump();
        AnimatorController();
        Attack();
    }

    // 移动
    void Run()
    {
        var moveDirectionHorizontal = Input.GetAxisRaw("Horizontal");
        var moveDirectionVertical = Input.GetAxisRaw("Vertical");
        var velocity = _rigidbody2D.velocity;
        
        // X轴移动
        velocity = new Vector2(moveDirectionHorizontal * moveSpeed, velocity.y);
        // Y轴移动
        if (moveDirectionVertical < 0 && isGround && _platformController!=null && _platformController.CanDown())
        {
            _platformController.SetTriggerTure();
        }

        // 爬楼梯
        if (Mathf.Abs(moveDirectionVertical) > Mathf.Epsilon && _ladderController != null &&
            _ladderController.CanCLimb())
        {
            isClimb = true;
            velocity = new Vector2(velocity.x, moveDirectionVertical * moveSpeed);
        }
        _rigidbody2D.velocity = velocity;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlatformController>()!=null)
        {
            _platformController = other.GetComponent<PlatformController>();
        }
        if (other.GetComponent<LadderController>()!=null)
        {
            _ladderController = other.GetComponent<LadderController>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlatformController>() != null)
        {
            _platformController = null;
        }
        if (other.GetComponent<LadderController>() != null)
        {
            _ladderController = null;
            isClimb = false;
        }
    }

    // 移动反转
    void Flip()
    {
        var hasAxisSpeed = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;
        if (hasAxisSpeed)
        {
            var sr = GetComponent<SpriteRenderer>();
            if (_rigidbody2D.velocity.x > Mathf.Epsilon)
            {
                sr.flipX = false;
            }

            if (_rigidbody2D.velocity.x < Mathf.Epsilon)
            {
                sr.flipX = true;
            }
        }
    }

    // 跳跃
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                _rigidbody2D.velocity = new Vector2(0, jumpSpeed)* Vector2.up;
                _canDoubleJump = true;
            }else if (_canDoubleJump)
            {
                _rigidbody2D.velocity = new Vector2(0, doubleJumpSpeed) * Vector2.up;
                _canDoubleJump = false;
            }
        }
    }
    
    // 地面检测
    void CheckGround()
    {
        isGround = _boxCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    // 攻击
    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            _animator.SetTrigger("Attack");
        }
    }

    // 动画管理
    void AnimatorController()
    {
        if (isGround)
        {
            _animator.SetFloat("JumpY",0);
        }
        if (_rigidbody2D.velocity.y > 0.01f)
        {
            _animator.SetFloat("JumpY",1f);
        }
        if (!isGround && _rigidbody2D.velocity.y < 0.01f)
        {
            _animator.SetFloat("JumpY",-1f);
        }

        if (Mathf.Abs(_rigidbody2D.velocity.y) > 0.01f && isClimb)
        {
            _animator.SetBool("climb",true);
        }
        else if(_animator.GetBool("climb"))
        {
            _animator.SetBool("climb",false);
        }
        
        // 判断X轴是否有速度
        var hasAxisSpeed = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;
        if (hasAxisSpeed)
        {
            _animator.SetFloat("RunX",1f);
        }
        else
        {
            _animator.SetFloat("RunX",0);
        }
    }

}
