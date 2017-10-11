using UnityEngine.EventSystems;
using UnityEngine;
[RequireComponent(typeof(PlayerMotorScript))]
public class PlayerControlScript : MonoBehaviour
{
    public Intertactable focus;

    public LayerMask movementMask;
    Camera cam;
    PlayerMotorScript motor;
    PlayerManager playerManager;
    CharacterStats selfStats;
    Combat combat;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotorScript>();
        playerManager = PlayerManager.instance; // nhan player vao
        combat = GetComponent<Combat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return; //check xem co click len UI hay ko
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //move to a point
                //  Debug.Log("We hit" + hit.collider.name + " " + hit.point);
                motor.agent.stoppingDistance = 0f;
                motor.MoveToPoint(hit.point);

                //Stop forcusing anu objects
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Intertactable intertactable = hit.collider.GetComponent<Intertactable>();
                if (intertactable != null)
                {
                    SetFocus(intertactable); //thang player nhin vao con moi
                    Attack(intertactable);
                    Debug.Log("Player tan cong");
                }
            }
        }
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        motor.StopFollowingTarget();
    }

    void SetFocus(Intertactable newFocus)
    {
        if (newFocus != focus)//kiemtra doituong cu vs moi khac nhau hay khong
        {
            if (focus != null)
            {
                focus.OnDefocused();// defocus thang cu~
            }
            focus = newFocus; //lay thang moi vao
            motor.FollowTarget(newFocus);//di theo con moi            
        }
        newFocus.onFocused(transform);// con moi thay thang player
    }

    public void Attack(Intertactable target)
    {
        float distance = Vector3.Distance(target.interactableTranform.position, transform.position);
        //  if (distance < lookRadius)
        {
            // motor.agent.SetDestination(target.interactableTranform.position);
            //  FaceTarget();
            CharacterStats targetStats = target.GetComponent<EnermyStats>();
            // if (distance < enemy.radius)
            {
                if (targetStats != null)
                {
                    combat.Attack(targetStats); //tan cong nguoi choi
                }
            }
        }


    }

}
