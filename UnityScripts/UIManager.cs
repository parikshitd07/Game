using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject furniturePanel;
    public GameObject colorPanel;
    public GameObject aiPanel;
    public GameObject suggestionPanel;

    [Header("Furniture Buttons")]
    public Button[] furnitureButtons;
    
    [Header("Color Buttons")]
    public Button[] colorButtons;

    [Header("AI Controls")]
    public TMP_InputField preferenceInput;
    public Button getSuggestionsButton;
    public Button clearRoomButton;

    [Header("Suggestion Display")]
    public GameObject suggestionItemPrefab;
    public Transform suggestionContainer;

    [Header("References")]
    public FurniturePlacement furniturePlacement;
    public WallColorChanger wallColorChanger;
    public AIDecorSuggestions aiSuggestions;

    [Header("Info Text")]
    public TextMeshProUGUI infoText;

    void Start()
    {
        SetupFurnitureButtons();
        SetupColorButtons();
        SetupAIControls();
        
        ShowInfo("Welcome! Click furniture buttons to place items, or get AI suggestions.");
    }

    void SetupFurnitureButtons()
    {
        for (int i = 0; i < furnitureButtons.Length; i++)
        {
            int index = i; // Capture for closure
            if (furnitureButtons[i] != null)
            {
                furnitureButtons[i].onClick.AddListener(() => OnFurnitureButtonClick(index));
            }
        }
    }

    void SetupColorButtons()
    {
        for (int i = 0; i < colorButtons.Length; i++)
        {
            int index = i;
            if (colorButtons[i] != null)
            {
                colorButtons[i].onClick.AddListener(() => OnColorButtonClick(index));
            }
        }
    }

    void SetupAIControls()
    {
        if (getSuggestionsButton != null)
        {
            getSuggestionsButton.onClick.AddListener(OnGetSuggestionsClick);
        }

        if (clearRoomButton != null)
        {
            clearRoomButton.onClick.AddListener(OnClearRoomClick);
        }
    }

    void OnFurnitureButtonClick(int index)
    {
        if (furniturePlacement != null)
        {
            furniturePlacement.SelectFurniture(index);
            ShowInfo($"Furniture selected! Click on the floor to place it. Right-click to cancel.");
        }
    }

    void OnColorButtonClick(int index)
    {
        if (wallColorChanger != null)
        {
            wallColorChanger.ChangeWallColor(index);
            ShowInfo($"Wall color changed!");
        }
    }

    void OnGetSuggestionsClick()
    {
        if (aiSuggestions != null && preferenceInput != null)
        {
            string preference = preferenceInput.text;
            if (string.IsNullOrEmpty(preference))
            {
                preference = "modern";
            }
            
            ShowInfo("Getting AI suggestions...");
            aiSuggestions.RequestSuggestions(preference);
        }
    }

    void OnClearRoomClick()
    {
        if (furniturePlacement != null)
        {
            furniturePlacement.ClearAllFurniture();
            ShowInfo("Room cleared!");
        }
    }

    public void DisplaySuggestions(List<DecorSuggestion> suggestions)
    {
        // Clear existing suggestions
        foreach (Transform child in suggestionContainer)
        {
            Destroy(child.gameObject);
        }

        // Display new suggestions
        for (int i = 0; i < suggestions.Count; i++)
        {
            int index = i;
            DecorSuggestion suggestion = suggestions[i];
            
            GameObject suggestionItem = Instantiate(suggestionItemPrefab, suggestionContainer);
            
            // Setup suggestion display
            TextMeshProUGUI titleText = suggestionItem.transform.Find("Title").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI descText = suggestionItem.transform.Find("Description").GetComponent<TextMeshProUGUI>();
            Button applyButton = suggestionItem.transform.Find("ApplyButton").GetComponent<Button>();
            
            if (titleText != null) titleText.text = suggestion.styleName;
            if (descText != null) descText.text = suggestion.description;
            if (applyButton != null)
            {
                applyButton.onClick.AddListener(() => OnApplySuggestion(index));
            }
        }

        if (suggestionPanel != null)
        {
            suggestionPanel.SetActive(true);
        }

        ShowInfo($"{suggestions.Count} style suggestions ready! Click 'Apply' on any to use it.");
    }

    void OnApplySuggestion(int index)
    {
        if (aiSuggestions != null)
        {
            aiSuggestions.ApplySuggestion(index);
            List<DecorSuggestion> suggestions = aiSuggestions.GetCurrentSuggestions();
            if (index < suggestions.Count)
            {
                ShowInfo($"Applied: {suggestions[index].styleName}");
            }
        }
    }

    public void ShowInfo(string message)
    {
        if (infoText != null)
        {
            infoText.text = message;
        }
        Debug.Log(message);
    }

    public void TogglePanel(GameObject panel)
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}
