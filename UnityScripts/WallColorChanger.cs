using UnityEngine;

public class WallColorChanger : MonoBehaviour
{
    public GameObject[] walls; // Assign all wall objects in the inspector
    public Material wallMaterial; // Material to modify
    
    private Color[] presetColors = new Color[]
    {
        new Color(0.95f, 0.95f, 0.95f), // White
        new Color(0.8f, 0.85f, 0.9f),   // Light Blue
        new Color(0.9f, 0.85f, 0.75f),  // Beige
        new Color(0.7f, 0.8f, 0.7f),    // Sage Green
        new Color(0.9f, 0.9f, 0.8f),    // Cream
        new Color(0.85f, 0.75f, 0.8f),  // Soft Pink
        new Color(0.7f, 0.7f, 0.75f)    // Gray
    };

    void Start()
    {
        if (walls.Length == 0)
        {
            // Auto-find walls if not assigned
            walls = GameObject.FindGameObjectsWithTag("Wall");
        }
    }

    public void ChangeWallColor(int colorIndex)
    {
        if (colorIndex >= 0 && colorIndex < presetColors.Length)
        {
            ChangeWallColor(presetColors[colorIndex]);
        }
    }

    public void ChangeWallColor(Color newColor)
    {
        foreach (GameObject wall in walls)
        {
            Renderer renderer = wall.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = newColor;
            }
        }
    }

    public void ChangeWallColorRGB(float r, float g, float b)
    {
        Color newColor = new Color(r, g, b);
        ChangeWallColor(newColor);
    }

    public Color GetCurrentWallColor()
    {
        if (walls.Length > 0)
        {
            Renderer renderer = walls[0].GetComponent<Renderer>();
            if (renderer != null)
            {
                return renderer.material.color;
            }
        }
        return Color.white;
    }

    public Color[] GetPresetColors()
    {
        return presetColors;
    }
}
