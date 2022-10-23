using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScenarioPlayer : MonoBehaviour
{
    public static ScenarioPlayer Instance{ get; }

    private static ScenarioPlayer instance;

    [SerializeField]
    private TextMeshProUGUI messageText;

    [SerializeField]
    private TextMeshProUGUI nameText;

    [SerializeField]
    private GameObject textRoot;

    [SerializeField]
    private Image nextUI;

    [SerializeField]
    private Image bgImage;

    [SerializeField]
    private Image fadeImage;

    [SerializeField]
    private Image leftChara;

    [SerializeField]
    private Image rightChara;

    bool isPlay = false;

    int currentIndex = 0;

    int currentTextCount = 1;

    float timer = 0f;

    bool inputSpace = false;

    [SerializeField]
    ScenarioEvent testData;

    private void Start() {
        instance = this;
        isPlay = false;

        StartCoroutine(Execute(testData));
    }

    public void PlayScenario(string EventLabel)
    {
        var data = Resources.Load<ScenarioEvent>("Database/Scenario/ScenarioData_" + EventLabel + ".asset");

        if(data == null)
        {
            Debug.Log("データが存在しません");
            return;
        }

        StartCoroutine(Execute(data));

    }

    IEnumerator Execute(ScenarioEvent data)
    {
        isPlay = true;
        while (true)
        {
            var item = data.GetEventData(currentIndex);

            if(item == null) break;

            if(!isPlay) yield break;

            switch (item.type)
            {
                // 会話イベント
                case ScenarioEvent.EventType.Talk:
                
                nextUI.gameObject.SetActive(false);
                var eventTextData = (ScenarioEvent.TalkPlayData)item;
                //このタイミングでキャラ立ち絵取得 event.CharacterID
                leftChara.gameObject.SetActive(
                    eventTextData.Position == ScenarioEvent.Pos.Left
                    || (leftChara.gameObject.activeSelf && eventTextData.Position != ScenarioEvent.Pos.None)
                    );
                rightChara.gameObject.SetActive(
                    eventTextData.Position == ScenarioEvent.Pos.Right
                    || (rightChara.gameObject.activeSelf && eventTextData.Position != ScenarioEvent.Pos.None)
                    );

                nameText.text = eventTextData.Name;
                if(eventTextData.Name.Length != 0 && eventTextData.Message.Length != 0){
                    textRoot.SetActive(true);
                    var textCor = TextEvent(eventTextData.Message);
                    while(textCor.MoveNext())
                    {
                        yield return null;
                    }

                    nextUI.gameObject.SetActive(true);


                    while(!Input.anyKey)
                    {
                        if(Input.GetKey(KeyCode.S))
                        {
                            break;
                        }

                        if(Input.GetKey(KeyCode.A))
                        {
                            break;
                        }
                        else if(Input.GetKeyDown("space"))
                        {
                            inputSpace = true;
                            break;
                        }

                        yield return null;
                    }
                }
                else
                {
                    textRoot.SetActive(false);
                    messageText.text = "";
                }

                yield return new WaitForSeconds(0.2f);

                currentIndex++;
                break;

                // 背景イベント
                case ScenarioEvent.EventType.BG:

                currentIndex++;
                break;

                // フェードイン
                case ScenarioEvent.EventType.FadeIn:
                var eventFadeInData = (ScenarioEvent.FadePlayData)item;
                var fadeInCor = FadeEvent(eventFadeInData.FadeIn, eventFadeInData.FadeColor, eventFadeInData.FadeTime);
                while(fadeInCor.MoveNext())
                {
                    yield return null;
                }
                currentIndex++;
                break;

                // フェードアウト
                case ScenarioEvent.EventType.FadeOut:
                var eventFadeOutData = (ScenarioEvent.FadePlayData)item;
                var fadeOutCor = FadeEvent(eventFadeOutData.FadeIn, eventFadeOutData.FadeColor, eventFadeOutData.FadeTime);
                while(fadeOutCor.MoveNext())
                {
                    yield return null;
                }
                currentIndex++;
                break;

                default:
                break;
            }
        }

        Finish();
    }

    IEnumerator TextEvent(string text)
    {
        while (true)
        {
            if(currentTextCount >= text.Length) break;

            string now = text.Substring(currentTextCount-1,1);

            if(now == "<" ) 
            {
                currentTextCount++;
                now = text.Substring(currentTextCount-1,1);

                while(now != ">")
                {
                    currentTextCount++;
                    now = text.Substring(currentTextCount-1,1);
                }
            }

            //テキストの一括表示
            if(Input.GetKey(KeyCode.Space))
            {
                if(!inputSpace)
                {
                    inputSpace = true;
                    currentTextCount = text.Length;
                }
            }
            else
            {
                inputSpace = false;
            }

            if(Input.GetKey(KeyCode.S))
            {
                var fadeOutColor = FadeEvent(false, Color.black, 0.5f);
                while(fadeOutColor.MoveNext())
                {
                    yield return null;
                }
                Finish();
                yield break;
            }

            //あと何文字
            messageText.text = text.Substring(0,currentTextCount);

            currentTextCount++;
            
            while(timer <= 0.1f) 
            {            
                timer += Time.deltaTime;
                yield return null;
            }
            timer = 0f;
        }
        currentTextCount = 1;
    }

    IEnumerator FadeEvent(bool fadeIn, Color color, float time)
    {
        Color imageColor = color;
        imageColor.a = fadeIn ? 1.0f : 0.0f;
        while (true)
        {
            if(fadeIn)
            {
                imageColor.a -= Time.deltaTime / time;
                fadeImage.color = imageColor;
                if(imageColor.a <= 0)
                {
                    break;
                }
            }
            else
            {
                imageColor.a += Time.deltaTime / time;
                fadeImage.color = imageColor;
                if(imageColor.a >= 1)
                {
                    break;
                }
            }
            yield return null;
        }
    }

    private void Finish()
    {
        isPlay = false;
    }
}
