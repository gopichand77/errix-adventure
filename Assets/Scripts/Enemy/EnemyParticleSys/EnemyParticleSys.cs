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
     private UnityEngine.Object exploRef;
    // Start is called before the first frame update
   private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       
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
            health -=5;
         
            spriteRenderer.material = matWhite;
             GameObject explosion = (GameObject)Instantiate(exploRef);
            explosion.transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
            if(health <= 0){
                KillSelf();
            }
        
        else
        {
            Invoke("ResetMaterial", 0.2f);
        }

    }
    }
    private void KillSelf(){
       
        Destroy(gameObject);
    }
    public void ResetMaterial()
    {
        spriteRenderer.material = matDefault;

    }

}
