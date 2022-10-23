using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioEvent : ScriptableObject
{
    /// <summary>
    /// イベントタイプ
    /// </summary>
    public enum EventType
    {
        Talk,
        BG,
        FadeIn,
        FadeOut,
        Wait,
    }

    /// <summary>
    /// キャラ立ち絵表示位置　左0右1
    /// </summary>
    public enum Pos
    {
        Left,
        Right,
        None,
    }

    /// <summary>
    /// テキストボックスに対しての演出
    /// </summary>
    public enum TextBoxEvent
    {
        None,
    }

    /// <summary>
    /// 会話イベントリスト
    /// </summary>
    public TalkPlayData[] talkEventList;
    /// <summary>
    /// 背景イベントリスト
    /// </summary>
    public BGPlayData[] bgEventList;
    /// <summary>
    /// 背景イベントリスト
    /// </summary>
    public FadePlayData[] fadeEventList;

    /// <summary>
    /// シナリオイベントベース
    /// </summary>
    [System.Serializable]
    public class TalkEventBase
    {
        public int ID;
        public EventType type;
    }

    /// <summary>
    /// 会話イベントクラス
    /// </summary>
    [System.Serializable]
    public class TalkPlayData : TalkEventBase
    {
        public string CharacterID;
        public Pos Position;
        public string Name;
        public TextBoxEvent EventType;
        public string Message; 
    }

    /// <summary>
    /// 背景イベントクラス
    /// </summary>
    [System.Serializable]
    public class BGPlayData : TalkEventBase
    {
        public string BGID;
    }

    /// <summary>
    /// 背景イベントクラス
    /// </summary>
    [System.Serializable]
    public class FadePlayData : TalkEventBase
    {
        public bool FadeIn; 
        public Color FadeColor;
        public float FadeTime;
    }

    /// <summary>
    /// データの設定
    /// </summary>
    /// <param name="talkDatas">会話イベント</param>
    /// <param name="bgDatas">背景イベント</param>
    public void SetData(TalkPlayData[] talkDatas, BGPlayData[] bgDatas, FadePlayData[] fadeDatas)
    {
        talkEventList = talkDatas;
        bgEventList = bgDatas;
        fadeEventList = fadeDatas;
    }

    /// <summary>
    /// 再生イベントの取得処理、取得時にtypeを確認して再生データを変換する必要あり
    /// </summary>
    /// <param name="index">再生位置のindex</param>
    /// <returns>再生データ（TalkEventBase）</returns>
    public TalkEventBase GetEventData(int index)
    {
        foreach (var item in talkEventList)
        {
            if(item.ID == index) return item;
        }

        foreach (var item in bgEventList)
        {
            if(item.ID == index) return item;
        }

        foreach (var item in fadeEventList)
        {
            if(item.ID == index) return item;
        }

        return null;
    }
}
