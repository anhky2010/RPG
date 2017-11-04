using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModeChange : MonoBehaviour {

    [SerializeField] private GameObject Cam_1;
    [SerializeField] private GameObject Cam_2;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ChangeMode();
	}

    private void ChangeMode()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {

            Cam_1.SetActive(!Cam_1.activeSelf);
            Cam_2.SetActive(!Cam_2.activeSelf);
        }
    }
}
