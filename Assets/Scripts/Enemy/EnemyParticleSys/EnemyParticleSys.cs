using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticleSys : MonoBehaviour
{
    private Material matWhite;

    private Material matDefault;
    SpriteRenderer spriteRenderer;
    public int health = 10;
    public int damage;
    public bool Dead = false;
    // public Transform WormPoint;
    public Transform PrefferedObject;
    private UnityEngine.Object exploRef;
    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // GetComponent<CameraShake>();
        // GetComponent<Camera>();

        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = spriteRenderer.material;
        exploRef = Resources.Load("Explosion");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Bullet"))//collisons 
        {
            Destroy(trig.gameObject);
            health -= 5;

            spriteRenderer.material = matWhite;

            if (health <= 0)
            {
                Dead = true;

                Invoke("KillSelf", 0.2f);
            }
            else
            {
                Invoke("ResetMaterial", 0.2f);
            }

        }
    }
    public void KillSelf()
    {
        Destroy(gameObject);
        
        GameObject explosion = (GameObject)Instantiate(exploRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(PrefferedObject, transform.position, Quaternion.identity);
    }
    public void ResetMaterial()
    {
        spriteRenderer.material = matDefault;
    }

}
