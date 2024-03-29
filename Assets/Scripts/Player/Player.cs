using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace Player
{
    public class Player : MonoBehaviour
    {
        // 移动速度
        public float moveSpeed=4f;
        // 跳跃高度
        public float jumpHeight=3f;
    
        // 输入参数
        private float _horizontal,_vertical;
    
        // 组件参数
        private Rigidbody2D _rigidbody2D;
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            // 获取输入
            _horizontal = Input.GetAxisRaw("Horizontal");
        }

        private void FixedUpdate()
        {
            // 获取坐标
            Vector2 position = _rigidbody2D.position;
            position.x += moveSpeed * Time.deltaTime * _horizontal;
        
            // 跳跃
            if (Input.GetKeyDown(KeyCode.Space))
            {
                position.y += jumpHeight;
            }
            // 刚体移动
            _rigidbody2D.MovePosition(position);
        }
    }
}
