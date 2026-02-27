using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{

    private Camera cam;
    [SerializeField] GameObject manager;

    Collider2D target;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        var rayHit = Physics2D.GetRayIntersection(cam.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider)
        {
            if(target)
            {
                target.gameObject.GetComponent<Person>().NameHover(false);
                target = null;
            }
            return;
        }
        target = rayHit.collider;
        target.gameObject.GetComponent<Person>().NameHover(true);
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.started || !target) return;

        manager.GetComponent<GameManager>().Problem(target.gameObject);
    }

}
