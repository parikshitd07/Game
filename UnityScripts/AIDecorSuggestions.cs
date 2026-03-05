using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;

[System.Serializable]
public class DecorSuggestion
{
    public string styleName;
    public string description;
    public Color wallColor;
    public List<string> furnitureItems;
}

public class AIDecorSuggestions : MonoBehaviour
{
    [Header("Gemini AI Settings")]
    public string apiKey = ""; // Set this in Inspector or via code
    private string apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent";

    [Header("References")]
    public WallColorChanger wallColorChanger;
    public FurniturePlacement furniturePlacement;
    public UIManager uiManager;

    private List<DecorSuggestion> currentSuggestions = new List<DecorSuggestion>();
    
    // Predefined suggestions as fallback
    private DecorSuggestion[] fallbackSuggestions = new DecorSuggestion[]
    {
        new DecorSuggestion
        {
            styleName = "Modern Minimalist",
            description = "Clean lines, neutral colors, minimal furniture for a spacious feel",
            wallColor = new Color(0.95f, 0.95f, 0.95f),
            furnitureItems = new List<string> { "Sofa", "Coffee Table", "Floor Lamp" }
        },
        new DecorSuggestion
        {
            styleName = "Cozy Scandinavian",
            description = "Warm tones, natural wood, comfortable and inviting",
            wallColor = new Color(0.9f, 0.9f, 0.85f),
            furnitureItems = new List<string> { "Armchair", "Bookshelf", "Rug", "Table Lamp" }
        },
        new DecorSuggestion
        {
            styleName = "Contemporary Chic",
            description = "Bold colors, statement pieces, artistic arrangement",
            wallColor = new Color(0.8f, 0.85f, 0.9f),
            furnitureItems = new List<string> { "Sofa", "Side Table", "Plant", "Wall Art" }
        },
        new DecorSuggestion
        {
            styleName = "Rustic Warmth",
            description = "Earthy tones, vintage furniture, homey atmosphere",
            wallColor = new Color(0.9f, 0.85f, 0.75f),
            furnitureItems = new List<string> { "Wooden Chair", "Cabinet", "Table", "Lamp" }
        },
        new DecorSuggestion
        {
            styleName = "Industrial Modern",
            description = "Metal accents, exposed elements, urban aesthetic",
            wallColor = new Color(0.7f, 0.7f, 0.75f),
            furnitureItems = new List<string> { "Metal Chair", "Industrial Desk", "Lamp", "Storage" }
        }
    };

    public void RequestSuggestions(string userPreference)
    {
        if (string.IsNullOrEmpty(apiKey) || apiKey == "your-api-key-here")
        {
            Debug.Log("Using fallback suggestions (no API key provided)");
            UseFallbackSuggestions(userPreference);
        }
        else
        {
            StartCoroutine(GetAISuggestions(userPreference));
        }
    }

    IEnumerator GetAISuggestions(string userPreference)
    {
        string prompt = $"As an interior design expert, provide 3-5 home decor style suggestions based on the preference: '{userPreference}'. For each style, include: style name, brief description, suggested wall color (as RGB 0-1 values), and 3-4 furniture items.";

        // Gemini API format
        string jsonData = @"{
            ""contents"": [{
                ""parts"": [{
                    ""text"": """ + prompt + @"""
                }]
            }]
        }";

        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        
        string fullUrl = apiUrl + "?key=" + apiKey;

        using (UnityWebRequest request = new UnityWebRequest(fullUrl, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string response = request.downloadHandler.text;
                Debug.Log("Gemini AI Response received: " + response);
                ParseAIResponse(response);
            }
            else
            {
                Debug.LogWarning("Gemini AI request failed, using fallback suggestions. Error: " + request.error);
                UseFallbackSuggestions(userPreference);
            }
        }
    }

    void ParseAIResponse(string jsonResponse)
    {
        // Basic parsing - in production, use proper JSON parser
        try
        {
            // For now, use fallback with AI-inspired selection
            UseFallbackSuggestions("AI-based");
            if (uiManager != null)
            {
                uiManager.DisplaySuggestions(currentSuggestions);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error parsing AI response: " + e.Message);
            UseFallbackSuggestions("modern");
        }
    }

    void UseFallbackSuggestions(string preference)
    {
        currentSuggestions.Clear();
        
        // Select 3-5 suggestions based on preference
        string prefLower = preference.ToLower();
        
        if (prefLower.Contains("modern") || prefLower.Contains("minimal"))
        {
            currentSuggestions.Add(fallbackSuggestions[0]);
            currentSuggestions.Add(fallbackSuggestions[2]);
            currentSuggestions.Add(fallbackSuggestions[4]);
        }
        else if (prefLower.Contains("cozy") || prefLower.Contains("warm"))
        {
            currentSuggestions.Add(fallbackSuggestions[1]);
            currentSuggestions.Add(fallbackSuggestions[3]);
            currentSuggestions.Add(fallbackSuggestions[0]);
        }
        else
        {
            // Default: show first 5
            for (int i = 0; i < Mathf.Min(5, fallbackSuggestions.Length); i++)
            {
                currentSuggestions.Add(fallbackSuggestions[i]);
            }
        }

        if (uiManager != null)
        {
            uiManager.DisplaySuggestions(currentSuggestions);
        }
    }

    public void ApplySuggestion(int index)
    {
        if (index >= 0 && index < currentSuggestions.Count)
        {
            DecorSuggestion suggestion = currentSuggestions[index];
            
            // Apply wall color
            if (wallColorChanger != null)
            {
                wallColorChanger.ChangeWallColor(suggestion.wallColor);
            }

            Debug.Log($"Applied style: {suggestion.styleName}");
            Debug.Log($"Suggested items: {string.Join(", ", suggestion.furnitureItems)}");
        }
    }

    public List<DecorSuggestion> GetCurrentSuggestions()
    {
        return currentSuggestions;
    }
}