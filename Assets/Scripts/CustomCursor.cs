using UnityEngine;

public class CustomCursor : MonoBehaviour
{

    public Texture2D defaultCursor;

    public Texture2D clickCursor;

    void Update()

    {

        Vector2 hotspot = new Vector2(25, 12);

        if (Input.GetMouseButtonDown(0))

        {
            Cursor.SetCursor(clickCursor, hotspot, CursorMode.Auto);
        }

        else if (Input.GetMouseButtonUp(0))

        {
            Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
        }

    }
}