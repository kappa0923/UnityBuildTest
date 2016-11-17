using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;

/**
 * コマンドラインからapkをビルドするクラス
 * Assets\Editor\ に配置する
 */
public class MyBuilder : MonoBehaviour {
    /*
     * コマンドラインからapkをビルドする
     * メニューからも実行できる
     * @code bundleIdentifier アプリごとに一意
     * @code bundleVersion ビルドバージョン
     */
    [MenuItem("Build/BuildAndroid")]
    public static void BuildProjectAllSceneAndroid() {
        EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.Android );
        string outputPath = Application.dataPath + "/../debug-app.apk";
        PlayerSettings.bundleIdentifier = "jp.kappa0923.unity_test";
        PlayerSettings.bundleVersion = "1.0";
        PlayerSettings.statusBarHidden = true;
        string[] levels = GetAllScenePaths;
        string errorMessage = BuildPipeline.BuildPlayer(
            levels,
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

    /**
     * 全シーンを取得
     * @return 全シーンのリスト
     */
    private static string[] GetAllScenePaths() {
        return EditorBuildSettings.scenes.Select(scene => scene.path).ToArray();
    }
}
