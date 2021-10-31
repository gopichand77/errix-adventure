using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// URL for the video : https://youtu.be/GgNLr7SSh1I --> to collect coins to ui
// URL for the video : https://youtu.be/UfGtgjnz6Go --> to splash the coins on the ground when the chest is collected
// https://simmer.io/@DucVu_FX/ultimate-impact-fx --> particle system to destroy 
    //--> https://assetstore.unity.com/packages/vfx/particles/ultimate-impact-fx-178389


public class CoinCollect : MonoBehaviour
{

    public float speed;

    public Transform target;
    // public Transform initial;
    public GameObject coinPrefab;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    public void StatCoinMove(Vector3 initial, Action onComplete)
    {
        // Vector3 initialPos = cam.ScreenToWorldPoint(new Vector3(initial.x, initial.y, cam.transform.position.z * -1));
        Vector3 targetPos = cam.ScreenToWorldPoint(new Vector3(target.position.x, target.position.y, cam.transform.position.z * -1));
        GameObject coin = Instantiate(coinPrefab, transform);

        StartCoroutine(MoveCoin(coin.transform, initial, targetPos, onComplete));
    }

    IEnumerator MoveCoin(Transform obj, Vector3 startPos, Vector3 endPos, Action onComplete)
    {
        float time = 0;
        while (time < 1)
        {
            time += speed * Time.deltaTime;
            obj.position = Vector3.Lerp(startPos, endPos, time);
            yield return new WaitForEndOfFrame();
        }
        onComplete.Invoke();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
