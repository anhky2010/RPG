using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    public float zoomSpeed = 4;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float pitch = 2f;
    public float currentZoom = 10f;


    // Update is called once per frame
    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        TranparentObject();

    }

    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
    }


    void TranparentObject()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Renderer rend = hit.transform.GetComponent<Renderer>();
            if (rend)
            {
                // Change the material of all hit colliders
                // to use a transparent shader.
                
                rend.material.shader = Shader.Find("Transparent/Diffuse");
                Color tempColor = rend.material.color;
                tempColor.a = 0.0F;
                rend.material.color = tempColor;
            }
           
           
        }
    }
}
