using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CamState
{
    public Transform target;
    public float speed;

    public Vector2 center;
    public Vector2 size;
}

public class CamControl : MonoBehaviour
{
    [SerializeField]
    CamState cam = new CamState();
    float height, width;

    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(cam.center, cam.size);
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cam.target.position, Time.deltaTime * cam.speed);

        float lx = cam.size.x * 0.5f - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + cam.center.x, lx + cam.center.x);

        float ly = cam.size.y * 0.5f - height;
        float clampY = Mathf.Clamp(transform.position.y, ly + cam.center.y, ly + cam.center.y);

        transform.position = new Vector3(clampX, clampY, -10f);
    }
}
