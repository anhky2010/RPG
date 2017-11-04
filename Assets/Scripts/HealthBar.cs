using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    [SerializeField] Transform parentTranform;
    EnermyStats enermyStats;
    UnityEngine.UI.Image img;

    private void Start()
    {
        Combat.instance.onCombat += ShowCurrentHP;
        enermyStats = GetComponentInParent<EnermyStats>();
        img = GetComponent<UnityEngine.UI.Image>();

    }

    void LateUpdate()
    {
        FaceCamera();
    }
    private void FaceCamera()
    {
        transform.eulerAngles = Camera.main.transform.eulerAngles;
        parentTranform.transform.eulerAngles = Camera.main.transform.eulerAngles;
    }
    private void ShowCurrentHP()
    {

        img.fillAmount = (float)enermyStats.currentHealth / enermyStats.maxHealth;

    }
}
