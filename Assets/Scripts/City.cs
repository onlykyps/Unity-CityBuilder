using UnityEngine;

public class City : MonoBehaviour
{
    // notes on city resource manager

    // jobsCeiling = factories * 10
    // currentJobs = min(currentPopulation, jobsCeiling)
    // currentFood += farms*4

    // populationCeiling = houses*5
    // if currentFood >= currentPopulation && currentPopulation < populationCeiling
        // currentFood -= currentPopulation * .25f
        // currentPopulation = min(currentPopulation += currentFood * .20f, populationCeiling)

    // cash += currentJobs * 2

    public int Cash {get; set;}
    public int Day {get; set;}
    public float PopulationCurrent {get; set;}
    public float PopulationCeiling {get; set;}
    public int JobsCurrent {get; set;}
    public int JobsCeiling {get; set;}
    public float Food {get; set;}

    public int[] buildingCounts = new int[4];

    public UI_Controller uiController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cash = 100000;
        Food = 6;
        JobsCeiling = 10;
        uiController = GetComponent<UI_Controller>();
    }

    public void EndTurn()
    {
        Day++;
        CalculatePopulation();
        CalculateJob();
        CalculateFood();
        CalculateCash();
        Debug.Log("Day ended.");
        uiController.UpdateCityData();
        uiController.UpdateDayCount();
        Debug.LogFormat
        ("Jobs: {0}/{1}, Cash:{2}, Pop:{3}/{4}, Food{5}",
        JobsCurrent, JobsCeiling, Cash, PopulationCurrent, PopulationCeiling, Food);
    }

    void CalculateJob()
    {
        JobsCeiling = buildingCounts[2] * 10;
        JobsCurrent = Mathf.Min((int)PopulationCurrent, JobsCeiling);
    }

    void CalculateCash()
    {
        Cash +=JobsCurrent * 2;
    }

    public void DepositCash(int cash)
    {
        Cash += cash;
    }
    void CalculateFood()
    {
        Food += buildingCounts[1] * 4f;
    }

    void CalculatePopulation()
    {
        PopulationCeiling = buildingCounts[0] * 5;
        if(Food >= PopulationCurrent && PopulationCurrent < PopulationCeiling)
        {
            Food -= PopulationCurrent * .25f;
            PopulationCurrent = Mathf.Min(PopulationCurrent += Food * .25f, PopulationCeiling);
        }
        else if (Food < PopulationCurrent)
        {
            PopulationCurrent -= (PopulationCurrent - Food) * .5f;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
