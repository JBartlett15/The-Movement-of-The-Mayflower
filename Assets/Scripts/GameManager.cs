using UnityEngine;

public class GameManager : MonoBehaviour
{

    float timer;
    int day;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 20;
        day = 0;
    }

    // Took 64 days, and so if aiming for 20 minutes of play, 1 minute makes 3.2 days, rounded down to 3 makes 1 day every 20 seconds
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 20)
        {
            day += 1;
            print("Day " + day);
            timer = 0;
        }
    }
}
