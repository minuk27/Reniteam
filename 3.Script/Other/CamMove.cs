using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Place
{
    Home_PlayerRoom, Home_LivingRoom, Home_Yard, Town, Voice
}

public class CamMove : MonoBehaviour
{
    private static CamMove camMove;
    public static CamMove camM
    {
        get
        {
            if(camMove == null)
            {
                return null;
            }
            return camMove;
        }
    }

    [SerializeField] private CamControl cam;

    private void Awake()
    {
        if (camMove)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        camMove = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void PlaceCam(Place p)
    {
        cam.CamMove(p);
    }
}
