using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _mTarget;
    void Start()
    {
        _mTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // 更新完成之后再更新摄像机位置
    private void LateUpdate()
    {
        var position = _mTarget.position;
        transform.localPosition = new Vector3(position.x, position.y, -10);
    }
}
