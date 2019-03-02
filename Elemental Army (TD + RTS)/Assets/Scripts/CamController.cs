using UnityEngine;

public class CamController : MonoBehaviour {
    public float panBorderThichness = 10f;
    public float panSpeed = 10f;
    public float scrollSpeed = 20f;
    public float smoothPanSpeed = 5f;
    public float smoothScrollSpeed = 3f;
    public Vector2 panLimit;
    public float minY = 10;
    public float maxY = 40;
    public Vector3 mapCenter;

    public Transform followTarget;

    private Transform camTransform;
    private Vector3 targetPosition;
    private float targetHeight;
    private float distance;
    private float heightDif;

	void Start () {
        //currentOffset = defaultOffset;   
        targetHeight = transform.position.y;
        targetPosition = new Vector3(transform.position.x, 0, transform.position.z);
	}
	
	void Update () {
        float panStep = smoothPanSpeed * Time.deltaTime;
        float scrollStep = smoothPanSpeed * Time.deltaTime;
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThichness)
        {
            targetPosition.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThichness)
        {
            targetPosition.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThichness)
        {
            targetPosition.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThichness)
        {
            targetPosition.x += panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        targetHeight -= scroll * scrollSpeed * 100f * Time.deltaTime;

        targetPosition.x = Mathf.Clamp(targetPosition.x, -panLimit.x + mapCenter.x, panLimit.x + mapCenter.x);
        targetHeight = Mathf.Clamp(targetHeight, minY, maxY);
        targetPosition.z = Mathf.Clamp(targetPosition.z, -panLimit.y + mapCenter.z, panLimit.y + mapCenter.z);

        distance = Mathf.Sqrt(Mathf.Pow(targetPosition.x - transform.position.x, 2) + Mathf.Pow(targetPosition.z - transform.position.z, 2));
        heightDif = targetHeight - transform.position.y;

        if(Mathf.Abs(distance) > .05f)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPosition.x, transform.position.y, targetPosition.z), panStep);
        if(Mathf.Abs(heightDif) > .05f)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,targetHeight, transform.position.z), scrollStep);
    }
}
