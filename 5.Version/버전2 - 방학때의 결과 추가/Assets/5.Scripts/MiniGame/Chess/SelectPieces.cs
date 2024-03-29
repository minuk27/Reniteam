using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SelectPieces
{
    public void Move(Vector2 vec, int index);
    public void Select();
    public void Check(int index);
    public void Delete();
}
