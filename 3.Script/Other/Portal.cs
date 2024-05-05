using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private GameObject position;
    [SerializeField]
    private Place place;
    

    public Vector2 Position { get { return position.transform.position; } }
    public Place GetPlace { get { return place; } }
}
