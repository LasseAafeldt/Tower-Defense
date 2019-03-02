using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;

    public Vector3 unitPosOffset;

    [Header("Optinal field")]
    public GameObject unit;
    private Color startColor;
	private Renderer rend;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + unitPosOffset;
    } 

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.canBuild)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (!buildManager.canBuild)
        {
            return;
        }
        if (unit != null)
        {
            Debug.Log("Can't build here!!! Tile already occupied.    TO DO: display on screen");
            return;
        }

        buildManager.BuildUnitOn(this);

    }
}
