using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;


    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Seleted");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("MissileLauncher Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }  
    
    public void SelectLaserBeamer()
    {
        Debug.Log("LaserBeamer Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
        