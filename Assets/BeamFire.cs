using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamFire : MonoBehaviour
{

    public Camera mainCam;
    public Transform spawn;
    public GameObject[] effects;
    public Transform parentObj;
    private int count = 0;
    // public Text text;
    bool isBeam = false;

    // Use this for initialization
    void Start()
    {
        //    text.text = effects[count].name;
    }
    public Transform ske;
    // Update is called once per frame
    void Update()
    {
        if (ske != null)
            ShotBeam(ske);
    }
    public void ShotBeam(Transform targer)
    {

        {
            Vector3 point = targer.transform.position;
            transform.LookAt(point);
        }
        //Shoot
        if (isBeam == false)
        {
            isBeam = true;
            GameObject beam = Instantiate(effects[count], spawn.position, spawn.rotation);
            beam.transform.parent = parentObj;
        }
    }
}
