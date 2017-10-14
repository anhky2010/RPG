using UnityEngine.EventSystems;
using UnityEngine;
[RequireComponent(typeof(PlayerMotorScript))]
public class PlayerControlScript : MonoBehaviour
{
    public Intertactable focus;
    public LayerMask movementMask;
    public GameObject hitMark;
    Camera cam;
    PlayerMotorScript motor;
    PlayerManager playerManager;
    PlayerStats playerStats;
    Combat combat;

    Intertactable intertactable = null;

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
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return; //check xem co click len UI hay ko
        }
        SetHitMark();
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(1))
        {
            intertactable = null;
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                hitMark.SetActive(true);
                motor.agent.stoppingDistance = 0f;
                motor.MoveToPoint(hit.point);
                //Stop forcusing any objects
                RemoveFocus();
                hitMark.transform.position = hit.point + new Vector3(0, 0.1f, 0);
                hitMark.transform.rotation = Quaternion.Euler(90, 0, 0);
                hit_point = hit.point;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            intertactable = null;
            if (Physics.Raycast(ray, out hit, 100))
            {
                hitMark.SetActive(false);
                intertactable = hit.collider.GetComponent<Intertactable>();
                if (intertactable != null)
                {
                    if (intertactable.GetType().IsAssignableFrom(typeof(ItemPickup)))
                    {
                        motor.agent.stoppingDistance = 0f;
                        SetFocus(intertactable);
                        return;
                    }
                    SetFocus(intertactable); //thang player nhin vao con moi
                    Attack(intertactable);
                }
            }
        }
        if (intertactable != null && intertactable.GetType().IsAssignableFrom(typeof(EnermyScript)) == true)
        {
            SetFocus(intertactable); //thang player nhin vao con moi
            Attack(intertactable);
        }
    }
    Vector3 hit_point;
    void SetHitMark()
    {
        if (playerManager.player.transform.position.x == hit_point.x &&
            playerManager.player.transform.position.z == hit_point.z)
        {
            hitMark.SetActive(false);
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
                //RemoveFocus();
                Debug.Log("Player tan cong");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, playerStats.attackRange.GetFinalValue());
    }
}
