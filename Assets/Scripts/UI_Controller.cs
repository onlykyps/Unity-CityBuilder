using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    private City city;

    [SerializeField]
    private UnityEngine.UI.Text dayText;

    [SerializeField]
    private UnityEngine.UI.Text cityText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // looking through all my objects
        // city = FindObjectOfType<City>();
        // has a smaller search field
        city = this.GetComponent<City>(); // both components are on the same object and can talk to each other
    }

    public void UpdateCityData()
    {
        cityText.text = string.Format
            ("Jobs: {0}/{1}\nCash: ${2} (+${6})\nPopulation: {3}/{4}\nFood: {5}",
            city.JobsCurrent, city.JobsCeiling, 
            city.Cash, (int)city.PopulationCurrent, 
            (int)city.PopulationCeiling, (int)city.Food, city.JobsCurrent*2);
    }

    public void UpdateDayCount()
    {
        dayText.text = string.Format("Day: {0}", city.Day);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
