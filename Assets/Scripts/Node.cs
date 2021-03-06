using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    // HoverColor
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;



    [Header("Optional")]
    public GameObject turret;


    //Get Mesh Renderer
    private Renderer rend;
    // Start Color Store through Start Fun
    private Color startColor;   

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = GetComponent<Renderer>().material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        // !buildManager.canBuild mean is change the opposite if true change to false or false change to true
        if (!buildManager.CanBuild)
            return;
        if (turret != null)
        {
            Debug.Log("Can't build there - TODO : Display On Screen");
            return;
        }

        // Build a turret
        //GameObject turretToBuild = buildManager.GetTurretToBuild();
        // turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

        buildManager.BuildTurretOn(this);
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;   

    }
}
