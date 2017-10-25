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
    SkillManager skillManager;
    Intertactable intertactable = null;
    float lookSize = 0f;
    float defaultRange;
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotorScript>();
        playerManager = PlayerManager.instance; // nhan player vao
        combat = GetComponent<Combat>();
        playerStats = GetComponent<PlayerStats>();
        skillManager = SkillManager.instance;
        defaultRange = motor.agent.stoppingDistance;
        lookSize = playerStats.attackRange.GetFinalValue();
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
            if (Physics.Raycast(ray, out hit, 100))
            {
                intertactable = hit.collider.GetComponent<Intertactable>();
                if (intertactable != null)
                {
                    motor.agent.speed = PlayerStats.instance_player.speed.GetFinalValue();
                    //nhat item
                    if (intertactable.GetType().IsAssignableFrom(typeof(ItemPickup)))
                    {
                        motor.agent.stoppingDistance = 0f;
                        SetFocus(intertactable);
                        motor.FollowTarget(intertactable);
                        return;
                    }
                    //tan cong enermy
                    else if (intertactable.GetType().IsAssignableFrom(typeof(EnermyScript)) == true)
                    {
                        SetFocus(intertactable);
                        motor.FollowTarget(intertactable);
                        Attack(intertactable);
                    }
                }

                //click phai de di den vi tri chuot
                if (intertactable == null)
                {
                    RemoveFocus();
                    motor.agent.stoppingDistance = 0f;
                    motor.MoveToPoint(hit.point);

                    hitMark.SetActive(true);
                    hitMark.transform.position = hit.point + new Vector3(0, 0.1f, 0);
                    hitMark.transform.rotation = Quaternion.Euler(90, 0, 0);
                    hit_point = hit.point;
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                intertactable = hit.collider.GetComponent<Intertactable>();
                if (intertactable != null)
                {
                    hitMark.SetActive(false);
                }
            }
        }
        if (intertactable != null && intertactable.GetType().IsAssignableFrom(typeof(EnermyScript)) == true)
        {
            SetFocus(intertactable); //thang player nhin vao con moi
            Attack(intertactable);
        }
        if (intertactable != null)
        {
            SkillAttack(intertactable);
            motor.LookTarget(intertactable);
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
        if (intertactable != null)
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
    public void SkillAttack(Intertactable target)
    {
        float distance = Vector3.Distance(target.interactableTranform.position, transform.position);
        //set khoang cach dung nhan vat ung voi attack range 
        CharacterStats targetStats = target.GetComponent<EnermyStats>();
        if (targetStats != null)
        {
            UseSkill(target.interactableTranform.position, distance, targetStats);

        }

    }

    public void UseSkill(Vector3 _pos, float _dis, CharacterStats _targerStat)
    {
        Vector3 offset = new Vector3(0, 0, 0);
        int _dmg = 0;
        int _range = 0;
        if (skillManager.CastSkill(_pos + offset, _dis, ref _dmg, ref _range))
        {

            combat.SkillAttack(_targerStat, 0, _dmg);
            motor.agent.stoppingDistance = _range;
            Debug.Log("Player dung skill dmg " + _dmg);
        }


    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, lookSize);
    }
}
