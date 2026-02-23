using UnityEngine;

public class Person : MonoBehaviour
{
    public string fullName;
    public bool hasProblem;
    [SerializeField] GameObject exPoint;


    private void OnMouseDown()
    {
        print("Schmello");
    }


    void ProblemState(bool problem)
    {
        if (problem)
        {
            hasProblem = true;
            exPoint.SetActive(true);
        }
        else
        {
            exPoint.SetActive(false);
            hasProblem = false;
        }
    }
}
