using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class MyBuilder : MonoBehaviour {
    // ビルド実行でAndroidのapkを作成する例
    [MenuItem("Build/BuildAndroid")]
    public static void BuildProjectAllSceneAndroid() {
        EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.Android );
        string outputPath = Application.dataPath + "/../debug-app.apk";
        PlayerSettings.bundleIdentifier = "jp.kappa0923.unity_test";
        PlayerSettings.bundleVersion = "1.0";
        PlayerSettings.statusBarHidden = true;
        string errorMessage = BuildPipeline.BuildPlayer(
            EditorBuildSettings.scenes,
            outputPath,
            BuildTarget.Android,
            BuildOptions.None
        );

        if (string.IsNullOrEmpty(errorMessage)) {
            Debug.Log("[Success]");
        } else {
            Debug.Log("[Failure]" + errorMessage);
        }
    }
}
