using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFloating : MonoBehaviour
{
    [SerializeField] GameObject HealthFloatingObj;

    // Use this for initialization
    void Start()
    {
        Combat.instance.onCombat += CreateHPFloating;
    }


    private void CreateHPFloating()
    {
        GameObject tempHP = Instantiate(HealthFloatingObj, transform.position, transform.rotation);
        RectTransform rt = tempHP.GetComponent<RectTransform>();
        float _x = Random.Range(-0.5f, 0.5f);
        rt.position = rt.position + new Vector3(_x, 0f, 0f);
        tempHP.transform.parent = this.transform;

    }

    private void OnDestroy()
    {
        Combat.instance.onCombat -= CreateHPFloating;
    }
}
