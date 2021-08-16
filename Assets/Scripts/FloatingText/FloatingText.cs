using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public void DestroyFloatingText(){
        GameObject parent = gameObject.transform.parent.gameObject;//to get the parent transform 
        StartCoroutine(DestroyText());
        // Destroy(parent);

        IEnumerator DestroyText(){
            yield return new WaitForSeconds(2f);
            Destroy(parent);
        }
    }
}
