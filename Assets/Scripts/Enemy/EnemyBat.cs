using UnityEngine;

namespace Enemy
{
    public class EnemyBat: Enemy
    {
        public float startWaitTime;
        public int speed;
        public Transform moveTarget,leftDown, rightUp;

        private float _waitTime;
        
        new void Start()
        {
            base.Start();
            moveTarget.position = GetRandomPosition();
            _waitTime = startWaitTime;
        }
        
        new void Update()
        {
            base.Update();

            // 将当前位置移向指定位置
            transform.position = Vector2.MoveTowards(transform.position, moveTarget.position, speed * Time.deltaTime);
            
            // 判断是否到达指定位置
            if (Vector2.Distance(transform.position, moveTarget.position) < Mathf.Epsilon)
            {
                if (_waitTime <= 0)
                {
                    moveTarget.position = GetRandomPosition();
                    _waitTime = startWaitTime;
                }
                else
                {
                    _waitTime -= Time.deltaTime;
                }
            }
        }

        Vector2 GetRandomPosition()
        {
            var movePosition = new Vector2(Random.Range(leftDown.position.x, rightUp.position.x),
                Random.Range(leftDown.position.y, rightUp.position.y));
            return movePosition;
        }
    }
}
