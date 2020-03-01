using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorScript: MonoBehaviour
{

    public Texture2D cursorArrow;
    public Texture2D cursorGlow;

    void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseEnter(){
        Cursor.SetCursor(cursorGlow, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseExit(){
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

}
