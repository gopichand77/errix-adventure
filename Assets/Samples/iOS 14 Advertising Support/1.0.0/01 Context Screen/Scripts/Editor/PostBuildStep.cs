using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.Callbacks;
#if UNITY_IOS
using UnityEditor.iOS.Xcode;
#endif
using System.IO;

// #if UNITY_IOS
public class PostBuildStep
{
<<<<<<< Updated upstream
    // // Set the IDFA request description:
    // const string k_TrackingDescription = "Your data will be used to provide you a better and personalized ad experience.";

    // [PostProcessBuild(0)]
    // public static void OnPostProcessBuild(BuildTarget buildTarget, string pathToXcode)
    // {
    //     if (buildTarget == BuildTarget.iOS)
    //     {
    //         AddPListValues(pathToXcode);
    //     }
    // }

    // // Implement a function to read and write values to the plist file:
    // static void AddPListValues(string pathToXcode)
    // {
    //     // Retrieve the plist file from the Xcode project directory:
    //     string plistPath = pathToXcode + "/Info.plist";
    //     PlistDocument plistObj = new PlistDocument();


    //     // Read the values from the plist file:
    //     plistObj.ReadFromString(File.ReadAllText(plistPath));

    //     // Set values from the root object:
    //     PlistElementDict plistRoot = plistObj.root;

    //     // Set the description key-value in the plist:
    //     plistRoot.SetString("NSUserTrackingUsageDescription", k_TrackingDescription);

    //     // Save changes to the plist:
    //     File.WriteAllText(plistPath, plistObj.WriteToString());
    // }
=======
    // Set the IDFA request description:
    const string k_TrackingDescription = "Your data will be used to provide you a better and personalized ad experience.";
    // const Array sdk = 

    [PostProcessBuild(0)]
    public static void OnPostProcessBuild(BuildTarget buildTarget, string pathToXcode)
    {
        if (buildTarget == BuildTarget.iOS)
        {
            AddPListValues(pathToXcode);
        }
        else
        {
            Debug.Log("Android Build Success");
        }
    }

    // Implement a function to read and write values to the plist file:
    static void AddPListValues(string pathToXcode)
    {
        // Retrieve the plist file from the Xcode project directory:
        string plistPath = pathToXcode + "/Info.plist";
        PlistDocument plistObj = new PlistDocument();


        // Read the values from the plist file:
        plistObj.ReadFromString(File.ReadAllText(plistPath));

        // Set values from the root object:
        PlistElementDict plistRoot = plistObj.root;

        // Set the description key-value in the plist:
        plistRoot.SetString("NSUserTrackingUsageDescription", k_TrackingDescription);

        //adding the unity ads total of 51
        plistRoot.SetString("SKAdNetworkIdentifier", "238da6jt44.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "8s468mfl3y.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "22mmun2rn5.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "4pfyvq9l8r.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "9t245vhmpl.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "f73kdq92p3.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "5a6flpkh64.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "w9q455wk68.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "k674qkevps.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "av6w8kgt66.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "t38b2kh725.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "578prtvx9j.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "4fzdc2evr5.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "v79kvwwj4g.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "ppxm28t8ap.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "f38h382jlk.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "prcb7njmu6.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "lr83yxwka7.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "zmvfpc5aq8.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "mlmmfzh3r3.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "tl55sbb4fm.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "5lm9lj6jb7.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "f7s53z58qe.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "c6k4g5qg8m.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "2u9pt9hc89.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "4dzt52r2t5.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "glqzh8vgby.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "x44k69ngh6.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "mp6xlyr22a.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "9rd848q2bz.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "3rd42ekr43.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "v72qych5uu.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "3sh42y64q3.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "zq492l623r.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "cstr6suwn9.skadnetwork"); 
        plistRoot.SetString("SKAdNetworkIdentifier", "7ug5zh24hu.skadnetwork"); 
        plistRoot.SetString("SKAdNetworkIdentifier", "ydx93a7ass.skadnetwork"); 
        plistRoot.SetString("SKAdNetworkIdentifier", "yclnxrl5pm.skadnetwork"); 
        plistRoot.SetString("SKAdNetworkIdentifier", "488r3q3dtq.skadnetwork"); 
        plistRoot.SetString("SKAdNetworkIdentifier", "4468km3ulz.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "wzmmz9fp6w.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "44jx6755aq.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "424m5254lk.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "32z4fx6l9h.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "wg4vff78zm.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "hs6bdukanm.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "3qy4746246.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "s39g8k73mm.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "kbd757ywx3.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "m8dbw4sv7c.skadnetwork");
        plistRoot.SetString("SKAdNetworkIdentifier", "5tjdwbrq8w.skadnetwork");

        // Save changes to the plist:
        File.WriteAllText(plistPath, plistObj.WriteToString());
    }
>>>>>>> Stashed changes
}
// #endif