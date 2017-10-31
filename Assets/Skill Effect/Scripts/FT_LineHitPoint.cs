using UnityEngine;
using System.Collections;

public class FT_LineHitPoint : MonoBehaviour
{

    public bool freezeHeightPosition = true;
    public float heightValue = 1.5f;
    public Transform target;

    void Update()
    {
        target = GetComponentInParent<BeamFire>().ske;
        if (target != null)
        {
            if (freezeHeightPosition == false)
            {
                transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
                transform.LookAt(target.transform);
            }
            else
            {
                transform.position = new Vector3(target.position.x, heightValue, target.position.z);
                transform.LookAt(target.transform);
            }
        }



    }
}
