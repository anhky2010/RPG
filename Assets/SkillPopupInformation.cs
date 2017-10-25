using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillPopupInformation : MonoBehaviour
{
    Text[] list_Text;

    // Use this for initialization
    void Start()
    {
        list_Text = GetComponentsInChildren<Text>();
        list_Text[0].text = "A";
        list_Text[1].text = "B";
        list_Text[2].text = "C";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
