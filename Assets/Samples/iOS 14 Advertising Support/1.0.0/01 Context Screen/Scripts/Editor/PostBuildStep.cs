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
#if UNITY_IOS
public class PostBuildStep
{
    // Set the IDFA request description:
    const string k_TrackingDescription = "Your data will be used to provide you a better and personalized ad experience.";

    [PostProcessBuild(0)]
    public static void OnPostProcessBuild(BuildTarget buildTarget, string pathToXcode)
    {
        //appgroups
        //https://docs.unity3d.com/Manual/UnityCloudBuildiOS.html
        //https://docs.unity3d.com/ScriptReference/Callbacks.PostProcessBuildAttribute.html
        //https://answers.unity.com/questions/1646797/xcode-project-build-automation-setting-up-app-grou.html
        //https://documentation.onesignal.com/docs/ios-sdk-app-groups-setup
        //co.errix.errixsadventure.OneSignalNotificationServiceExtension
        
        // string projectPath = PBXProject.GetPBXProjectPath(pathToXcode);

        // string entitlementsPath = "Unity-iPhone.entitlements";

        // PBXProject project = new PBXProject();
        // project.ReadFromFile(projectPath);

        // //This is the same as going manually to Signing & Capabilities > pressing "+ Capability" > App Groups, then adding an entry for the desired group
        // ProjectCapabilityManager projectManager = new ProjectCapabilityManager(projectPath, entitlementsPath, null, project.GetUnityMainTargetGuid());
        // project.AddCapability(project.GetUnityMainTargetGuid(), PBXCapabilityType.AppGroups, entitlementsPath);
        // projectManager.AddAppGroups(new string[] { "group.97862CMFGR.co.errix.errixsadventure" });

        // projectManager.WriteToFile();
        // project.WriteToFile(projectPath);
        // //above

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

        // Get the path to the plist file: 

        //unity sdk
        string[] skAdNetwork = {
                            "238da6jt44.skadnetwork",
                            "8s468mfl3y.skadnetwork",
                            "22mmun2rn5.skadnetwork",
                            "4pfyvq9l8r.skadnetwork",
                            "5tjdwbrq8w.skadnetwork",
                            "9t245vhmpl.skadnetwork",
                            "f73kdq92p3.skadnetwork",
                            "5a6flpkh64.skadnetwork",
                            "w9q455wk68.skadnetwork",
                            "k674qkevps.skadnetwork",
                            "av6w8kgt66.skadnetwork",
                            "t38b2kh725.skadnetwork",
                            "578prtvx9j.skadnetwork",
                            "4fzdc2evr5.skadnetwork",
                            "v79kvwwj4g.skadnetwork",
                            "ppxm28t8ap.skadnetwork",
                            "f38h382jlk.skadnetwork",
                            "prcb7njmu6.skadnetwork",
                            "lr83yxwka7.skadnetwork",
                            "zmvfpc5aq8.skadnetwork",
                            "mlmmfzh3r3.skadnetwork",
                            "tl55sbb4fm.skadnetwork",
                            "5lm9lj6jb7.skadnetwork",
                            "f7s53z58qe.skadnetwork",
                            "c6k4g5qg8m.skadnetwork",
                            "2u9pt9hc89.skadnetwork",
                            "4dzt52r2t5.skadnetwork",
                            "glqzh8vgby.skadnetwork",
                            "x44k69ngh6.skadnetwork",
                            "mp6xlyr22a.skadnetwork",
                            "9rd848q2bz.skadnetwork",
                            "3rd42ekr43.skadnetwork",
                            "v72qych5uu.skadnetwork",
                            "3sh42y64q3.skadnetwork",
                            "zq492l623r.skadnetwork",
                            "cstr6suwn9.skadnetwork",
                            "7ug5zh24hu.skadnetwork",
                            "ydx93a7ass.skadnetwork",
                            "yclnxrl5pm.skadnetwork",
                            "488r3q3dtq.skadnetwork",
                            "4468km3ulz.skadnetwork",
                            "wzmmz9fp6w.skadnetwork",
                            "44jx6755aq.skadnetwork",
                            "424m5254lk.skadnetwork",
                            "32z4fx6l9h.skadnetwork",
                            "wg4vff78zm.skadnetwork",
                            "hs6bdukanm.skadnetwork",
                            "3qy4746246.skadnetwork",
                            "s39g8k73mm.skadnetwork",
                            "kbd757ywx3.skadnetwork",
                            "m8dbw4sv7c.skadnetwork",
    };
        // Retrieve the plist file from the Xcode project directory:
        string plistPath = pathToXcode + "/Info.plist";
        PlistDocument plistObj = new PlistDocument();


        // Read the values from the plist file:
        plistObj.ReadFromString(File.ReadAllText(plistPath));

        // Set values from the root object:
        PlistElementDict plistRoot = plistObj.root;

        // Set the description key-value in the plist:
        plistRoot.SetString("NSUserTrackingUsageDescription", k_TrackingDescription);
        // firebase error
        // plistRoot.SetBoolean("FirebaseAppDelegateProxyEnabled",false);
        // plistRoot.SetString("SKAdNetworkIdentifier", skadnetwork.ToString());
        for (int i = 0; i < skAdNetwork.Length; i++)
        {
            plistRoot.SetString("SKAdNetworkIdentifier", skAdNetwork[i]);
        }
        // Save changes to the plist:
        File.WriteAllText(plistPath, plistObj.WriteToString());
    }

}
#endif