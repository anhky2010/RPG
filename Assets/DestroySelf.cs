using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] float duration_Alive = 1;
    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, duration_Alive);
    }


}
