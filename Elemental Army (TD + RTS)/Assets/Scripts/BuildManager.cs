using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {
    public static BuildManager instance;
    private void Awake()
    {
        if(instance!= null)
        {
            Debug.LogError("More than 1 BuildManager in the scene!");
        }
        instance = this;
    }

    private UnitBlueprint turretToBuild;

    public bool canBuild { get { return turretToBuild != null; } }

    PlayerControler playerControler;
    private void Start()
    {
        playerControler = PlayerControler.instance;        
    }

    public void SelectTurretToBuild(UnitBlueprint selectedTurret)
    {
        turretToBuild = selectedTurret;
    }

    public void BuildUnitOn(Node node)
    {
        if(PlayerStats.avilibleUnits < turretToBuild.unitCost)
        {
            Debug.Log("No availible units!");
            return;
        }
        //move builder to build position
        PlayerControler.targetPos = node.GetBuildPosition();
        //set seethrough version of unit on build position
        StartCoroutine(MoveToBuildUnit(node));
    }

    IEnumerator MoveToBuildUnit(Node node)
    {
        Debug.Log("MoveToBuildUnit coroutine is unfinished!!!");
        yield return new WaitForSeconds(0.1f);        
        while (true)
        {            
            //remove seethrough version of unit on build position if player cancles move to build position

            if (playerControler.GetDistanceToTarget() <= .5)
            {
                //taking currency
                PlayerStats.avilibleUnits -= turretToBuild.unitCost;
                Debug.Log("Avaliable units: " + PlayerStats.avilibleUnits.ToString());
                //add unit travel time

                //building turret
                GameObject unit = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), node.transform.rotation);
                node.unit = unit;
                //remove seethrough version of unit
                yield break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
