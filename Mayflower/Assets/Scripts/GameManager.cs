using UnityEngine;

public class GameManager : MonoBehaviour
{

    float timer;
    int day;

    Vector3 mousePos;
    RaycastHit2D ray;
    Transform clickObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 20;
        day = 0;
    }

    // Took 64 days, and so if aiming for 20 minutes of play, 1 minute makes 3.2 days, rounded down to 3 makes 1 day every 20 seconds
    void Update()
    {
        mousePos = Input.mousePosition;

        Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            ray = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
            clickObject = ray ? ray.collider.transform : null;
            if(clickObject)
            {
                print("Mouseclick");
                clickObject.GetComponent<SpriteRenderer>().color = Color.red;
            } // https://www.youtube.com/watch?v=hs2TB3hdylk
        }

        timer += Time.deltaTime;
        if(timer >= 20)
        {
            day += 1;
            print("Day " + day);
            timer = 0;
        }
    }
}
