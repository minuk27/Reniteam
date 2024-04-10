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
    float minX, maxX, minY, maxY;

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

    public void CamMove(Place place)
    {
        switch (place)
        {
            case Place.Home_PlayerRoom:
                this.gameObject.transform.position = new Vector3(0, 30, -10);
                cam.center.x = 0; cam.center.y = 30;
                cam.size.x = 37; cam.size.y = 19;
                break;
            case Place.Home_LivingRoom:
                this.gameObject.transform.position = new Vector3(0, 0, -10);
                cam.center.x = 0; cam.center.y = 0;
                cam.size.x = 45; cam.size.y = 19;
                break;
            case Place.Home_Yard:
                this.gameObject.transform.position = new Vector3(-50, 0, -10);
                cam.center.x = -50; cam.center.y = 0;
                cam.size.x = 45; cam.size.y = 19;
                break;
            case Place.Town:
                this.gameObject.transform.position = new Vector3(-100, 0, -10);
                cam.center.x = -100; cam.center.y = 0;
                cam.size.x = 45; cam.size.y = 19;
                break;
        }
    }
}
