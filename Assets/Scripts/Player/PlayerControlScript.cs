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
    PlayerStats playerStats;
    Combat combat;
    float defaultRange;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotorScript>();
        playerManager = PlayerManager.instance; // nhan player vao
        combat = GetComponent<Combat>();
        playerStats = GetComponent<PlayerStats>();

        defaultRange = motor.agent.stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerGetHitPoint();
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
                motor.agent.stoppingDistance = 0f;
                motor.MoveToPoint(hit.point);
                //Stop forcusing any objects
                RemoveFocus();
                hit_point = hit.point;
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
    Vector3 hit_point;
    void SetPlayerGetHitPoint()
    {
        if (playerManager.player.transform.position.x == hit_point.x &&
            playerManager.player.transform.position.z == hit_point.z)
        {
            motor.agent.stoppingDistance = defaultRange;
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
        //set khoang cach dung nhan vat ung voi attack range 
        motor.agent.stoppingDistance = playerStats.attackRange.GetFinalValue();
        CharacterStats targetStats = target.GetComponent<EnermyStats>();
        if (distance < playerStats.attackRange.GetFinalValue())
        {
            if (targetStats != null)
            {
                combat.Attack(targetStats);
                motor.agent.stoppingDistance = playerStats.attackRange.GetFinalValue();
                RemoveFocus();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, playerStats.attackRange.GetFinalValue());
    }
}
