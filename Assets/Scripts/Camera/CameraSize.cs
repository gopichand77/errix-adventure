using UnityEngine;

public class CameraSize : MonoBehaviour
{
    //Target values for the zoom effect
    [SerializeField] float zoomInSpeed = 1f;
    [SerializeField] float zoomOutSpeed = 1f;
    [SerializeField] float targetZoomOut = .3f;

    //Initial value for zoom out effect
    float initalZoom = 0f;// I am just going to keep this typo after all :)
    float initialPosX;
    float initialPosY;

    //State bool for controling the methods
    public static bool IsZoomedIn = false;
    public static bool IsZoomedOut = false;

    //Cache reference
    private Transform target;
    private Camera cam;
    private bool zoomIn;
    private bool zoomOut;
    private bool zoom;
    private bool playerEnter = false;




    // Start is called before the first frame update
    //Initializing our values
    void Start()
    {
        cam = Camera.main;
        target = GameObject.FindWithTag("Player").transform;
        initalZoom = cam.orthographicSize;
        initialPosX = cam.transform.position.x;
        initialPosY = cam.transform.position.y;
    }
    private void Update()
    {

        if (zoomOut)
        {
            ZoomOutCamera();
            zoomIn = false;


        }
        if (zoomIn)
        {
            ZoomInCamera();
            zoomOut = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Player"))
        {
            playerEnter = true;
            zoomOut = true;
            zoomIn = false;
        }
    }
    private void OnTriggerExit2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Player"))
        {
            // ZoomInCamera();
            zoomOut = false;
            zoomIn = true;
        }
    }

    private void ZoomInCamera()
    {
        if (!IsZoomedIn)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, initalZoom, Time.deltaTime * zoomInSpeed);
            cam.transform.position = new Vector3(Mathf.Lerp(cam.transform.position.x, target.position.x, Time.deltaTime * zoomInSpeed),
                Mathf.Lerp(cam.transform.position.y, cam.transform.position.y, Time.deltaTime * zoomInSpeed),
                cam.transform.position.z);
        }
    }

    private void ZoomOutCamera()
    {


        if (!IsZoomedOut)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoomOut, Time.deltaTime * zoomInSpeed);
            cam.transform.position = new Vector3(Mathf.Lerp(cam.transform.position.x, target.position.x, Time.deltaTime * zoomInSpeed),
                Mathf.Lerp(cam.transform.position.y, cam.transform.position.y, Time.deltaTime * zoomInSpeed),
                cam.transform.position.z);
        }
    }

}