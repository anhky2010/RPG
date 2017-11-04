using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;

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

        if (!PlayerStats.instance.alive) return;
        SetHitMark();
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(1))
        {
            intertactable = null;
            if (Physics.Raycast(ray, out hit, 100))
            {
                intertactable = hit.collider.gameObject.GetComponentInParent<Intertactable>();
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
                        return;
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
                    return;
                }
            }
            //  return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                intertactable = hit.collider.gameObject.GetComponentInParent<Intertactable>();
                //  Debug.Log(hit.collider.name);
                if (intertactable != null)
                {
                    hitMark.SetActive(false);
                }
            }
        }

        SkillAttack(intertactable);
        AutoAttack(intertactable);
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
        PlayerAnimation pAni = PlayerAnimation.instance;
        CharacterStats targetStats = target.GetComponent<EnermyStats>();
        if (playerStats.curDCAtt > 0) return;

        if (!pAni.animator.GetCurrentAnimatorStateInfo(0).IsName("1HAttack"))
        {
            if (targetStats == null) return;

            //set khoang cach dung nhan vat ung voi attack range 
            //   motor.agent.stoppingDistance = playerStats.attackRange.GetFinalValue();
            motor.SetDistance(playerStats.attackRange.GetFinalValue(), target.radiusInteractable);
            float distance = Vector3.Distance(target.interactableTranform.position, transform.position);

            if (distance < playerStats.attackRange.GetFinalValue() + target.radiusInteractable)
            {
                motor.SetDistance(playerStats.attackRange.GetFinalValue(), target.radiusInteractable);
                pAni.AttackAnimation(playerStats.attackSpeed.GetFinalValue());
                combat.Attack(targetStats);
                //ss  motor.agent.stoppingDistance = playerStats.attackRange.GetFinalValue();              
                // Debug.Log("Player tan cong");
            }
        }

    }
    public void SkillAttack(Intertactable target)
    {
        if (target == null) return;
        float distance = Vector3.Distance(target.interactableTranform.position, transform.position);
        //set khoang cach dung nhan vat ung voi attack range 
        CharacterStats targetStats = target.GetComponent<EnermyStats>();
        if (targetStats != null)
        {
            motor.LookTarget(target);
            StartCoroutine(UseSkill(target.interactableTranform.position, distance, targetStats));
        }

    }

    IEnumerator UseSkill(Vector3 _pos, float _dis, CharacterStats _targerStat)
    {
        Vector3 offset = new Vector3(0, 0, 0);
        int _dmg = 0;
        int _range = 0;
        float _delay_Dmg = 0;
        int _times = 1; ;
        if (skillManager.CastSkill(_pos + offset, _dis, ref _dmg, ref _range, ref _delay_Dmg, ref _times))
        {
            motor.agent.stoppingDistance = _range;

            for (int i = 0; i < _times; i++)
            {
                combat.SkillAttack(_targerStat, _delay_Dmg, _dmg);
                Debug.Log("Player dung skill dmg " + _dmg);
                yield return new WaitForSeconds(0.5f);
            }

        }
    }
    public void AutoAttack(Intertactable target)
    {
        if (target != null && target.GetType().IsAssignableFrom(typeof(EnermyScript)))
        {
            SetFocus(target); //thang player nhin vao con moi
            Attack(target);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, lookSize);
    }


}
