using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _mTarget;

    public Vector2 minPox, maxPox;
    void Start()
    {
        _mTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // 更新完成之后再更新摄像机位置
    private void LateUpdate()
    {        
        Vector2 targetPos = _mTarget.position;
        // transform.localPosition = new Vector3(targetPos.x, targetPos.y, -10);
        // targetPos.x = Mathf.Clamp(targetPos.x, minPox.x, maxPox.x);
        // targetPos.y = Mathf.Clamp(targetPos.y, minPox.y, maxPox.y);
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPos.x, targetPos.y, -10), 0.1f);
    }

    // 设置相机边界
    public void SetCameraLimit(Vector2 min, Vector2 max)
    {
        minPox = min;
        maxPox = max;
    }
}
