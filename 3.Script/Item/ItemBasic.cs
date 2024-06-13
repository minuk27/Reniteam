using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemBasicDialog
{
    [Header("ด๋ป็")]
    public string explanation;
}

public class ItemBasic : MonoBehaviour
{
    [SerializeField] ItemBasicDialog dialog;

    public string getSpeech { get { return dialog.explanation; } }
}
