#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScenarioDataImporter : AssetPostprocessor
{
    private static string TextAssetDirPath = "Assets/Database/Scenario/";

    // 全てのアセットのインポートが完了した後に呼び出される
    private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
        string[] movedFromAssetPaths)
    {
        for(int i = 0; i < importedAssets.Length; i++)
        {
            // インポートファイルのPathが指定のディレクトリ・ファイル形式かチェック
            if(importedAssets[i].Contains(TextAssetDirPath) && importedAssets[i].Contains(".csv"))
            {
                var asset = (TextAsset)AssetDatabase.LoadAssetAtPath(importedAssets[i],typeof(TextAsset));

                CreateData(asset);
            }
        }
    }

    /// <summary>
    /// ScriptableObject生成
    /// </summary>
    /// <param name="textFile">対象csvファイル</param>
    private static void CreateData(TextAsset textFile)
    {
		// csvファイルをstring形式に変換
		string csvText = textFile.text;

		// 改行ごとにパース
		string[] afterParse = csvText.Split('\n');

        string fileName =  "ScenerioData_" + textFile.name + ".asset";
        string path = TextAssetDirPath + fileName;

        // ScriptableObjectの作成
        var talkData = ScriptableObject.CreateInstance<ScenarioEvent>();
        // 一時保存用リスト
        var talkList = new List<ScenarioEvent.TalkPlayData>();
        var bgList = new List<ScenarioEvent.BGPlayData>();

		// ヘッダー行を除いてインポート
		for (int i = 1; i < afterParse.Length; i++){
			string[] parseByComma = afterParse[i].Split(',');

			int column = 0;

			// 先頭の列が空であればその行は読み込まない
            if (parseByComma[column] == "") continue;
			if (parseByComma[column] == "Talk")
            {
                column++;

                // TalkEvent作成
                talkList.Add(AddTalkEvent(
                    i - 1,
                    parseByComma[column++],
                    int.Parse(parseByComma[column++]),
                    parseByComma[column++],
                    int.Parse(parseByComma[column++]),
                    parseByComma[column++]));
			}
            else if (parseByComma[column] == "BG")
            {
                column++;

                // BGEvent作成
                bgList.Add(AddBGEvent(
                    i - 1,
                    parseByComma[column++]));
            }
		}

        talkData.SetData(talkList.ToArray(),bgList.ToArray());

		// インスタンス化したものをアセットとして保存
        var asset = (ScenarioEvent)AssetDatabase.LoadAssetAtPath(path, typeof(ScenarioEvent));
        if (asset == null){
		    // 指定のパスにファイルが存在しない場合は新規作成
            AssetDatabase.CreateAsset(talkData, path);
        } else {
		    // 指定のパスに既に同名のファイルが存在する場合は更新
            EditorUtility.CopySerialized(talkData, asset);
            AssetDatabase.SaveAssets();
        }
		AssetDatabase.Refresh();
		Debug.Log(textFile.name + " : 敵データの作成が完了しました。");
    }

    /// <summary>
    /// 会話イベント生成
    /// </summary>
    public static ScenarioEvent.TalkPlayData AddTalkEvent(int id, string chara, int pos, string name, int textBox, string text)
    {
        var playData = new ScenarioEvent.TalkPlayData();
        playData.ID = id;
        playData.type = ScenarioEvent.EventType.Talk;
        playData.CharacterID = chara;
        playData.Position = (ScenarioEvent.Pos)pos;
        playData.Name = name;
        playData.EventType = (ScenarioEvent.TextBoxEvent)textBox;
        playData.Message = text;

        return playData;
    }

    /// <summary>
    /// 背景イベント生成
    /// </summary>
    public static ScenarioEvent.BGPlayData AddBGEvent(int id, string bg)
    {
        var playData = new ScenarioEvent.BGPlayData();
        playData.ID = id;
        playData.type = ScenarioEvent.EventType.BG;
        playData.BGID = bg;

        return playData;
    }
}
#endif