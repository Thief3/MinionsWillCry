using UnityEngine;
using System.Collections;

public class cursor : MonoBehaviour {
    [SerializeField]
    private Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    // Use this for initialization
    void Start() {
        Cursor.SetCursor(cursorTexture, new Vector2(12, 12), cursorMode);
    }
}
