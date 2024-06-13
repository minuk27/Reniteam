using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryScreen : MonoBehaviour
{
    [SerializeField] PlayerMove player;
    private void OnEnable()
    {
        player.moveStop();
    }
}