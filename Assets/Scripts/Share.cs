using System;
using UnityEngine;
using System.Collections;
using System.IO;


//this script works for both ios and android
public class Share : MonoBehaviour
{

    public string subject = "Now Play🎮 Errix's Adventure Game available on Apple AppStore & Google Playstore";
    public string link = "https://onelink.to/errixsadventure";

    public void ShareScreenShot()
    {
        StartCoroutine(TakeScreenShotShare());
    }

    public void ShareApp()
    {
        StartCoroutine(AppShare());
    }

    private IEnumerator TakeScreenShotShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D image = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        image.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        image.Apply();

        //store the screenshot on the temporary storage and converts to png
        string filePath = Path.Combine(Application.temporaryCachePath, "shared_img.png");
        File.WriteAllBytes(filePath, image.EncodeToPNG());

        Destroy(image);

        new NativeShare().AddFile(filePath).SetSubject(subject).SetText("Can you beat my High Score let's see!" + subject +"\n" + link).Share();
    }

    private IEnumerator AppShare()
    {
        //take the files from the assets to share the image
        Texture2D image = Resources.Load("logo", typeof(Texture2D)) as Texture2D;
        string filePath = Path.Combine(Application.temporaryCachePath, "shared_img.png");
        File.WriteAllBytes(filePath, image.EncodeToPNG());

        yield return null;

        new NativeShare().AddFile(filePath).SetSubject(subject).SetText(subject + "\n" + link).Share();
    }
}




