using UnityEngine;
using UnityEngine.EventSystems;

public class FurniturePlacement : MonoBehaviour
{
    public GameObject[] furniturePrefabs; // Array of furniture prefabs to place
    public float placementHeight = 0f; // Height at which to place furniture
    public LayerMask floorLayer; // Layer for the floor
    
    private GameObject selectedFurniture;
    private GameObject currentPreview;
    private int currentFurnitureIndex = 0;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Check if mouse is over UI
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // Show preview of furniture at mouse position
        if (selectedFurniture != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, floorLayer))
            {
                if (currentPreview == null)
                {
                    currentPreview = Instantiate(selectedFurniture, hit.point, Quaternion.identity);
                    SetTransparent(currentPreview, true);
                }
                else
                {
                    currentPreview.transform.position = new Vector3(hit.point.x, placementHeight, hit.point.z);
                }

                // Place furniture on left click
                if (Input.GetMouseButtonDown(0))
                {
                    PlaceFurniture(hit.point);
                }
            }
        }

        // Cancel placement on right click
        if (Input.GetMouseButtonDown(1) && currentPreview != null)
        {
            Destroy(currentPreview);
            currentPreview = null;
            selectedFurniture = null;
        }
    }

    public void SelectFurniture(int index)
    {
        if (index >= 0 && index < furniturePrefabs.Length)
        {
            currentFurnitureIndex = index;
            selectedFurniture = furniturePrefabs[index];
            
            if (currentPreview != null)
            {
                Destroy(currentPreview);
                currentPreview = null;
            }
        }
    }

    void PlaceFurniture(Vector3 position)
    {
        if (selectedFurniture != null)
        {
            Vector3 placePos = new Vector3(position.x, placementHeight, position.z);
            GameObject placed = Instantiate(selectedFurniture, placePos, Quaternion.identity);
            SetTransparent(placed, false);
            
            // Add tag for later management
            placed.tag = "PlacedFurniture";
        }
    }

    void SetTransparent(GameObject obj, bool transparent)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            if (transparent)
            {
                Color color = renderer.material.color;
                color.a = 0.5f;
                renderer.material.color = color;
            }
            else
            {
                Color color = renderer.material.color;
                color.a = 1f;
                renderer.material.color = color;
            }
        }
    }

    public void ClearAllFurniture()
    {
        GameObject[] placed = GameObject.FindGameObjectsWithTag("PlacedFurniture");
        foreach (GameObject obj in placed)
        {
            Destroy(obj);
        }
    }
}
