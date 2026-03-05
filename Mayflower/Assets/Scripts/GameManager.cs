using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    float timer;
    int currentDay;
    Month currentMonth;
    bool uiOpen;
    public int passengers;
    public bool timePaused;

    [SerializeField] TMP_Text dayText;
    [SerializeField] GameObject textBox;
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject[] people;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 20;
        currentDay = 15;
        currentMonth = Month.September;
        passengers = 101;
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
        if (timePaused) return;
        timer += Time.deltaTime;
        if (timer >= 1) //20
        {
            IncrementDay();
        }
    }

    void IncrementDay()
    {
        currentDay += 1;
        timer = 0;

        DayCheck();

        dayText.text = currentDay.ToString() + " " + currentMonth + " 1620";
    }

    public void Problem(GameObject person)
    {
        if (person.GetComponent<Person>().hasProblem && !uiOpen)
        {
            person.GetComponent<Person>().ClickedOn();
            textBox.SetActive(true);
            text.SetText(person.GetComponent<Person>().problem);
            uiOpen = true;
        }
    }

    public void CloseTextBox()
    {
        uiOpen = false;
        textBox.SetActive(false);
    }

    void DayCheck()
    {
        if (currentMonth == Month.September)
        {
            if(currentDay == 20)
            {
                people[0].GetComponent<Person>().SetProblemState(true);
            }
            else if(currentDay >= 31)
            {
                currentMonth = Month.October;
                currentDay = 1;
            }
        }
        else if (currentMonth == Month.October)
        {
            if (currentDay == 9)
            {
                people[1].GetComponent<Person>().SetProblemState(true);
            }
            else if(currentDay == 28)
            {
                people[3].GetComponent<Person>().SetProblemState(true);
            }
            else if (currentDay == 30)
            {
                people[2].GetComponent<Person>().SetProblemState(true);
            }
            else if (currentDay >= 32)
            {
                currentMonth = Month.November;
                currentDay = 1;
            }
        }
        else if (currentMonth == Month.November)
        {
            if (currentDay >= 32)
            {
                EndGame();
                return;
            }
        }
    }

    void EndGame()
    {
        print("Game Over");
        timePaused = true;
    }

}
