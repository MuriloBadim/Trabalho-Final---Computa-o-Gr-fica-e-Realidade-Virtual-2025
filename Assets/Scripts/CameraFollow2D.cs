using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.1f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
            transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed);
        }
    }
}
public class FollowShipUI : MonoBehaviour
{
    public Transform ship;        // nave no mundo
    public Vector3 offset;        // ajuste fino da posição
    public Camera cam;            // câmera do jogo
    RectTransform rt;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        if (cam == null) cam = Camera.main;
    }

    void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(ship.position);
        rt.position = screenPos + offset;
    }
}
