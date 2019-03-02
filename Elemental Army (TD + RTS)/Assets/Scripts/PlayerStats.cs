using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int avilibleUnits;
    public int startAvlibleUnits = 3;

    public static int livesLeft;


    private void Start()
    {
        avilibleUnits = startAvlibleUnits;
    }
}
