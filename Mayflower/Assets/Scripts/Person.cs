using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Person : MonoBehaviour
{
    public string fullName;
    public bool hasProblem;
    [SerializeField] GameObject exPoint;
    [SerializeField] TMP_Text nameText;
    public string problem;


    private void Start()
    {
        exPoint.SetActive(false);
        nameText.SetText("");
    }

    public void ClickedOn()
    {
        if (hasProblem) SetProblemState(false);
    }



    public void SetProblemState(bool problem)
    {
        if (problem) hasProblem = true;
        else hasProblem = false;
        
        exPoint.SetActive(hasProblem);
    }

    public void NameHover(bool state)
    {
        if (state) nameText.SetText(fullName);
        else nameText.SetText("");
    }
}
