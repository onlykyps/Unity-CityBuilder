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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
