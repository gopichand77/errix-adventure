using UnityEngine;

public class CameraSize : MonoBehaviour
{

   [SerializeField] float endOfZoomInCursor = .001f; 
    [SerializeField] float endOfZoomOutCursor = .05f;

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
    public Transform target;
    public Camera cam;
    public bool zoomin;
    public bool zoomout;
    public bool zoom;
    public bool playerenter= false;




    // Start is called before the first frame update
    //Initializing our values
    void Start()
    {
        cam = Camera.main;
        initalZoom = cam.orthographicSize;
        initialPosX = cam.transform.position.x;
        initialPosY = cam.transform.position.y;
    }
    private void Update()
    {
       
        if(zoomout)
        {
            ZoomOutCamera();
             zoomin = false;
            

        }
        if(zoomin)
        {
            ZoomInCamera();
            zoomout = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Player"))
        {
            playerenter = true;
            zoomout = true;
            zoomin = false;
        }
    }
    private void OnTriggerExit2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Player"))
        {
            // ZoomInCamera();
            zoomout = false;
            zoomin = true;
        }
    }

    public void ZoomInCamera()
    {
        if (!IsZoomedIn)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, initalZoom, Time.deltaTime * zoomInSpeed);
            cam.transform.position = new Vector3(Mathf.Lerp(cam.transform.position.x, target.position.x, Time.deltaTime * zoomInSpeed),
                Mathf.Lerp(cam.transform.position.y,cam.transform.position.y , Time.deltaTime * zoomInSpeed), 
                cam.transform.position.z);
            if (initalZoom<= endOfZoomInCursor)
            {
                IsZoomedIn = true;
                
            }
        }
    }

    public void ZoomOutCamera()
    {

       
        if (!IsZoomedOut)
        {
             cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoomOut, Time.deltaTime * zoomInSpeed);
            cam.transform.position = new Vector3(Mathf.Lerp(cam.transform.position.x, target.position.x, Time.deltaTime * zoomInSpeed),
                Mathf.Lerp(cam.transform.position.y, cam.transform.position.y, Time.deltaTime * zoomInSpeed), 
                cam.transform.position.z);
            if (initalZoom + targetZoomOut <= endOfZoomOutCursor)
            {
                IsZoomedOut = false;
                
            }
        }
    }

}