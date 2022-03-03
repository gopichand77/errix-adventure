using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel : MonoBehaviour
{
    Vector3 matric;
    internal GameObject cam;
    Vector3 moveToPosition;
    float speed = 2f;
    public bool move_ = false;
    public bool move_back = false;
    [SerializeField] 
    Transform EnemyTransform;
    [SerializeField]
    internal Transform PlayerTransform;
    [SerializeField]
    internal Player playerScript;
    [SerializeField]
    CameraController Camera;
    public float timer;
    public int stayTimer;
    private void Start()
    {
        timer = 6;
        // EnemyTransform = FindObjectOfType<Enemy_Behaviour>().transform;
        move_ = true;
        cam = gameObject;
        Camera = GetComponent<CameraController>();
        playerScript =  FindObjectOfType<Player>();
        PlayerTransform =  playerScript.transform;
        Camera.enabled = false;
        playerScript.MovementScript.ctrlActive = false;
        move();
        
        // PlayerTransform = 
    }

    void Update()
    {
        if(move_)
        {
            move();
            timer -= Time.deltaTime;

        }
        if(timer < 0)
        {
            move_ = false;
            Camera.enabled = true;
        }
         
    }

    // public void move()
    // {
    //     move_ = true;
    // }
    public void move()
    {
         moveToPosition = new Vector3(EnemyTransform.position.x, EnemyTransform.position.y, -10);
            cam.transform.position =
            Vector3.SmoothDamp(cam.transform.position,
                          moveToPosition,
                          ref matric, speed);
                          
            StartCoroutine(Move());

    }
    public void Back()
    {
        moveToPosition = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, -10);
            cam.transform.position =
            Vector3.SmoothDamp(cam.transform.position,
                          moveToPosition,
                          ref matric, speed);
        //  Camera.enabled = true;

    }
    IEnumerator Move()
    {
        if(move_back)
        {
        yield return new WaitForSeconds(2f);
        move_ = true;
        yield return new WaitForSeconds(timer);
        move_ = false;
        yield return new WaitForSeconds(stayTimer);
        move_back = true;
        yield return new WaitForSeconds(timer);
        move_back = false;
        yield return new WaitForSeconds(0.5f);
        Camera.enabled = true;
        playerScript.MovementScript.ctrlActive = true;

        }


    }
}
