using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRes : MonoBehaviour
{
    public GameObject backgroundImage;
    public Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        scaleBackgroundImageFitScreenSize();

    }

    public void scaleBackgroundImageFitScreenSize()
    {
        Vector2 deviveScreenResolution = new Vector2(Screen.width, Screen.height);
        // print(deviveScreenResolution);

        float srcheight = Screen.height;
        float srcWidth = Screen.width;

        float DEVICE_SCREEN_ASPECT = srcWidth / srcheight;
        // print("DEVICE_SCREEN_ASPECT" + DEVICE_SCREEN_ASPECT.ToString());

        //Main Camera Aspect == Device Aspect
        mainCam.aspect = DEVICE_SCREEN_ASPECT;

        //Scale BackGround Image to Fit

        float camHeight = 100.0f * mainCam.orthographicSize * 2.0f;
        float camWidth = camHeight * DEVICE_SCREEN_ASPECT;
        // print("camHeight:" + camHeight.ToString());
        // print("camWidth:" + camWidth.ToString());

        //Get Background image 

        SpriteRenderer backgroundImageSR = backgroundImage.GetComponent<SpriteRenderer>();
        float bgImgH = backgroundImageSR.sprite.rect.height;
        float bgImgW = backgroundImageSR.sprite.rect.width;

        // print("bgImhgH:" + bgImgH.ToString());
        // print("bgImgW:" + bgImgW.ToString());
        //
        float bgImg_scale_ratio_Height = camHeight / bgImgH;
        float bgImg_scale_ratio_Width = camHeight / bgImgW;

        backgroundImage.transform.localScale = new Vector3(bgImg_scale_ratio_Width, bgImg_scale_ratio_Height, 1);
    }
}
