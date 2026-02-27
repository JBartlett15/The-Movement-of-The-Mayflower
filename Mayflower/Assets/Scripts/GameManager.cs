using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    float timer;
    int currentDay;
    Month currentMonth;
    bool uiOpen;

    [SerializeField] TMP_Text dayText;
    [SerializeField] GameObject textBox;
    [SerializeField] TMP_Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 20;
        currentDay = 15;
        currentMonth = Month.September;
        textBox.SetActive(false);
    }

    enum Month
    {
        September,
        October,
        November
    }

    // Took 64 days, and so if aiming for 20 minutes of play, 1 minute makes 3.2 days, rounded down to 3 makes 1 day every 20 seconds
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1) //20
        {
            IncrementDay();
        }
    }

    void IncrementDay()
    {
        currentDay += 1;
        timer = 0;
        if (currentMonth == Month.September && currentDay >= 31)
        {
                currentMonth = Month.October;
                currentDay = 1;
        }
        else if (currentMonth == Month.October && currentDay >= 32)
        {
                currentMonth = Month.November;
                currentDay = 1;
        }
        else if (currentMonth == Month.November && currentDay >= 20)
        {
            
        }

        dayText.text = currentDay.ToString() + " " + currentMonth + " 1620";
    }

    public void Problem(GameObject person)
    {
        if (person.GetComponent<Person>().hasProblem && !uiOpen)
        {
            person.GetComponent<Person>().ClickedOn();
            textBox.SetActive(true);
            text.SetText(person.GetComponent<Person>().fullName + " is unhappy");
            uiOpen = true;
        }
    }

    public void CloseTextBox()
    {
        uiOpen = false;
        textBox.SetActive(false);
    }

}
