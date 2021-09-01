using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel : MonoBehaviour
{
    Vector3 matric;
    public GameObject cam;
    Vector3 moveToPosition;
    float speed = 2f;
    public bool move_ = false;
    public bool move_back = false;
    [SerializeField] Transform EnemyTransform;
    [SerializeField]
    Transform PlayerTransform;
    [SerializeField]
    Player playerScript;
    [SerializeField]
    CameraController Camera;
    public int timer;
    public int stayTimer;
    private void Start()
    {
        Camera.enabled = false;
        playerScript.MovementScript.ctrlActive = false;
        move_ = false;
        StartCoroutine(Move());
        // PlayerTransform = 
    }

    void Update()
    {
        if (move_)
        {
            //Assigning new position to moveTOPosition
            moveToPosition = new Vector3(EnemyTransform.position.x, EnemyTransform.position.y, -10);
            cam.transform.position =
            Vector3.SmoothDamp(cam.transform.position,
                          moveToPosition,
                          ref matric, speed);




        }
        if (move_back)
        {
            moveToPosition = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, -10);
            cam.transform.position =
            Vector3.SmoothDamp(cam.transform.position,
                          moveToPosition,
                          ref matric, speed);

        }
    }

    // public void move()
    // {
    //     move_ = true;
    // }
    IEnumerator Move()
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
