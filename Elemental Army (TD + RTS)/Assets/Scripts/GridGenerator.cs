using UnityEngine;

public class GridGenerator : MonoBehaviour {
    //public bool Overwrite;
    public GameObject gridParent;

    [Header("Grid Tile look")]
    public GameObject gridTilePrefab;

    [Header("Grid size")]
    public int x;
    public int y;
    public float tileSpace;
    public float height;

    public void generateGrid()
    {
        if (!gridTilePrefab.GetComponent<Renderer>())
        {
            Debug.LogWarning("Grid tile prefab is missing Rendere");
        }

        //float xOffset = gridTilePrefab.GetComponent<Renderer>().bounds.size.x;
        float tileSize = gridTilePrefab.GetComponent<Renderer>().bounds.size.z;

        float xOffset = gridTilePrefab.GetComponent<Transform>().lossyScale.x;
        for (int i = 0; i < x; i++)
        {
            float zOffset = gridTilePrefab.GetComponent<Renderer>().bounds.size.z;
            xOffset += tileSpace;
            for (int j = 0; j < y; j++)
            {
                zOffset += tileSpace;
                //Debug.Log("tile size: " + xOffset);
                Vector3 position = new Vector3(i *tileSize + xOffset, height, j*tileSize + zOffset);
                //position = position + transform.position;
                GameObject tile = Instantiate(gridTilePrefab, position, transform.rotation, gridParent.transform);
            }
        }
    }

    public void overwriteGrid()
    {
        deleteGrid();
        generateGrid();
    }

    public void deleteGrid()
    {
        while (gridParent.transform.childCount > 0)
        {
            for (int i = 0; i < gridParent.transform.childCount; i++)
            {
                DestroyImmediate(gridParent.transform.GetChild(0).gameObject);
            }
        }
        gridParent.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
    }
}
