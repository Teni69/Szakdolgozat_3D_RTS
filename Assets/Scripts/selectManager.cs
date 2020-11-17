using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectManager : MonoBehaviour
{
    public string selectableTag = "Selectable";
    public Material selectedMaterial;
    public Material defaultMaterial;
    private Transform _selection;
    public static bool isSelected;

    void Update()
    {
        if(_selection != null && isSelected == false)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        if(Input.GetKey(KeyCode.Escape) && isSelected == true)
        {
             isSelected = false;
        }
 
        Ray ray = Camera.main.ViewportPointToRay(Camera.main.ScreenToViewportPoint(Input.mousePosition));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if(selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if(selectionRenderer != null && isSelected == false)
                {
                    selectionRenderer.material = selectedMaterial;
                }
                if(Input.GetMouseButtonDown(0))
                {
                    selectionRenderer.material = selectedMaterial;
                    isSelected = true;
                }
                _selection = selection;
            }
        }
    }
}
