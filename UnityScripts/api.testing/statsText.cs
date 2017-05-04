using UnityEngine;

public class BoxExample : MonoBehaviour
{
    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "This is a box");
    }
}

public class BoxWithTextureExample : MonoBehaviour
{
    public Texture BoxTexture;      // Drag a Texture onto this item in the Inspector

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), BoxTexture);
    }
}

public class BoxWithContentExample : MonoBehaviour
{
    public Texture BoxTexture;      // Drag a Texture onto this item in the Inspector

    GUIContent content;

    void Start()
    {
        content = new GUIContent("This is a box", BoxTexture, "This is a tooltip");
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), content);
    }
}

public class BoxWithTextStyleExample : MonoBehaviour
{
    GUIStyle style = new GUIStyle();

    void Start()
    {
        // Position the Text in the center of the Box
        style.alignment = TextAnchor.MiddleCenter;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "This is a box", style);
    }
}

public class BoxWithTextureStyleExample : MonoBehaviour
{
    public Texture BoxTexture;              // Drag a Texture onto this item in the Inspector

    GUIStyle style = new GUIStyle();


    void Start()
    {
        // Position the Texture in the center of the Box
        style.alignment = TextAnchor.MiddleCenter;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), BoxTexture, style);
    }
}

public class BoxWithTextureStyleExample : MonoBehaviour
{
    public Texture BoxTexture;              // Drag a Texture onto this item in the Inspector

    GUIStyle style = new GUIStyle();


    void Start()
    {
        // Position the Texture in the center of the Box
        style.alignment = TextAnchor.MiddleCenter;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), BoxTexture, style);
    }
}
