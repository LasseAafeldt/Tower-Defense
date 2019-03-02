using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    public UnitBlueprint swordsMan;
    public UnitBlueprint archer;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectSwordsManTurret()
    {
        if(PlayerStats.avilibleUnits <= 0)
        {
            return;
        }
        Debug.Log("Swordsman selected!");
        buildManager.SelectTurretToBuild(swordsMan);
    }
    public void SelectArcherTurret()
    {
        if (PlayerStats.avilibleUnits <= 0)
        {
            return;
        }
        Debug.Log("Archer selected!");
        buildManager.SelectTurretToBuild(archer);
    }
}
