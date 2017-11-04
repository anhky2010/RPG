using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFloating : MonoBehaviour
{
    [SerializeField] GameObject HealthFloatingObj;
    EnermyStats enermyStats;

    // Use this for initialization
    void Start()
    {

        enermyStats = GetComponentInParent<EnermyStats>();
        enermyStats.onDoDamage += CreateHPFloating;
    }


    private void CreateHPFloating(int _dmg)
    {
        GameObject tempHP = Instantiate(HealthFloatingObj, transform.position, transform.rotation);
        RectTransform rt = tempHP.GetComponent<RectTransform>();
        TextMesh dmgTextMesh = tempHP.GetComponent<TextMesh>();
        dmgTextMesh.text = _dmg.ToString();
        float _x = Random.Range(-0.5f, 0.5f);
        rt.position = rt.position + new Vector3(_x, 0f, 0f);
        tempHP.transform.parent = this.transform;
    }

    private void OnDestroy()
    {
        enermyStats.onDoDamage -= CreateHPFloating;
    }
}
