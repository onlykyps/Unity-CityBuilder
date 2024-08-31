using UnityEngine;

public class BuildingController : MonoBehaviour
{

    [SerializeField]
    private City city;
    [SerializeField]
    private UI_Controller uiController;
    [SerializeField]
    private Building[] buildings;
    [SerializeField]
    private Board board;
    private Building selectedBuilding;
	
	

    void InteractWithBoard(int action)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 gridPosition = board.CalculateGridPosition(hit.point);
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                if (action == 0 && board.CheckForBuildingAtPosition(gridPosition) == null)
                {
                    if (city.Cash >= selectedBuilding.cost)
                    {
                        city.DepositCash(-selectedBuilding.cost);
                        uiController.UpdateCityData();
                        city.buildingCounts[selectedBuilding.id]++;
                        board.AddBuilding(selectedBuilding, gridPosition);
                    }
                }
                else if (action == 1 && board.CheckForBuildingAtPosition(gridPosition) != null)
                {
                    
                    city.DepositCash(board.CheckForBuildingAtPosition(gridPosition).cost/2);
                    board.RemoveBuilding(gridPosition);
                    uiController.UpdateCityData();
                }
            }
        }
    }

    public void EnableBuilder(int building)
    {
        selectedBuilding = buildings[building];
        Debug.Log("Selected building: " + selectedBuilding.buildingName);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift) && selectedBuilding != null)
        {
            InteractWithBoard(0);
        }
		else if (Input.GetMouseButtonDown(0) && selectedBuilding != null)
        {
            InteractWithBoard(0);
        }

        if (Input.GetMouseButtonDown(1))
        {
            InteractWithBoard(1);
        }
    }
}
