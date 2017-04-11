using UnityEngine;

public class GUIManager : MonoBehavior
{
    public RenderTexture MiniMapTexture;
    public Material MiniMapMaterial;

    priavte float offset;

    void Awake()
    {
        offset = 10;
  
    }

    void OnGUI()
    {
        if (Event.current.type == EventType.Repaint)
        {
            Graphics.DrawTexture(new Rect(Screen.width - 256 - offset, Screen.height + 256 + offset, 256, 256), MiniMapTexture, MiniMapMaterial);
        }
    }

	public Class1()
	{
	}
}
