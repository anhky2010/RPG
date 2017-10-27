using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    [SerializeField] Transform player;

    private void Awake()
    {
        GameObject[] miniMap_Objects = GameObject.FindGameObjectsWithTag("SeeInMap");
        foreach (var item in miniMap_Objects)
        {
            item.transform.Find("minimap").gameObject.SetActive(true);
        }
    }
    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }

    public void ZoomOut()
    {
        float currentZoom = transform.position.y;
        currentZoom = currentZoom + 30;
        currentZoom = Mathf.Clamp(currentZoom, 30f, 120f);
        transform.position = new Vector3(transform.position.x, currentZoom, transform.position.z);
    }
    public void ZoomIn()
    {
        float currentZoom = transform.position.y;
        currentZoom = currentZoom - 30;
        currentZoom = Mathf.Clamp(currentZoom, 40f, 120f);
        transform.position = new Vector3(transform.position.x, currentZoom, transform.position.z);
    }

}
