using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class MyBuilder {
    // ビルド実行でAndroidのapkを作成する例
    [UnityEditor.MenuItem("Tools/Build Project AllScene Android")]
    public static void BuildProjectAllSceneAndroid() {
        EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.Android );
        List<string> allScene = new List<string>();
        foreach( EditorBuildSettingsScene scene in EditorBuildSettings.scenes ){
            if (scene.enabled) {
                allScene.Add (scene.path);
            }
        }
        PlayerSettings.bundleIdentifier = "jp.kappa0923.unity_test";
        PlayerSettings.statusBarHidden = true;
        BuildPipeline.BuildPlayer(
            allScene.ToArray(),
            "debug-app.apk",
            BuildTarget.Android,
            BuildOptions.None
        );
    }
}
