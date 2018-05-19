using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent( typeof( PlayerMotor ) )]
public class PlayerController : MonoBehaviour
{
    public LayerMask moveMask;

    public Interactable focus;

    Camera cam;
    PlayerMotor motor;
    
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }
    
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if ( Input.GetMouseButton( 0 ) )
        {
            Ray ray = cam.ScreenPointToRay( Input.mousePosition );
            RaycastHit hit;

            if ( Physics.Raycast( ray, out hit, 100, moveMask ) )
            {
                // Move player towards hit.
                motor.MoveToPoint( hit.point );

                // Stop focusing any objects.
                RemoveFocus();
            } 
        }

        if ( Input.GetMouseButtonDown( 1 ) )
        {
            Ray ray = cam.ScreenPointToRay( Input.mousePosition );
            RaycastHit hit;

            if ( Physics.Raycast( ray, out hit, 100 ) )
            {
                // Check if we hit an interactable.
                // If true, set it as our focus.
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if ( interactable != null )
                {
                    SetFocus( interactable );
                }
            }
        }
    }

    void SetFocus( Interactable newFocus )
    {
        if ( newFocus != focus )
        {
            if ( focus != null )
            {
                focus.OnDefocus();
            }
            focus = newFocus;
            motor.FollowTarget( newFocus );
        }
        newFocus.OnFocus( transform );
    }

    void RemoveFocus()
    {
        if ( focus != null )
        {
            focus.OnDefocus();
        }
        focus = null;
        motor.StopFollowingTarget();
    }
}
