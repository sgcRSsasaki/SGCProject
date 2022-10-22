using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TectSetter : MonoBehaviour
{
    ScenarioEvent scenarioEvent = new  ScenarioEvent();
    int charaCount = 0;
    float timer = 0;
    bool progress = false;
    int currentMessageIndex = 0;

    [SerializeField]
    TextMeshProUGUI textUi;


    void Update()
    {
        timer += Time.deltaTime;
        if(timer <= 0.5f) 
        {
            return;
        }

        if(scenarioEvent.GetEventData(currentMessageIndex).type == ScenarioEvent.EventType.Talk )
        {
            if(charaCount >= (ScenarioEvent.TalkPlayData)(scenarioEvent.GetEventData(currentMessageIndex)).Message.Length)
            {
                charaCount = 0;
                currentMessageIndex++;
                return;
            }
        }
            charaCount++;


        //Talk,BGの判定
        if(scenarioEvent.GetEventData(currentMessageIndex).type == ScenarioEvent.EventType.Talk )
        {
            //Talkの場合、文の取得
            string text = (ScenarioEvent.TalkPlayData)(scenarioEvent.GetEventData(currentMessageIndex)).Message;
            
            //現在の文字
            string now = text.subString(charaCount-1,1);
            if(now = "<" ) 
            {
                charaCount++;
                now = text.subString(charaCount-1,1);

                while(now != ">")
                {
                    charaCount++;
                    now = text.subString(charaCount-1,1);
                }
            }
            //あと何文字
            text.subString(0,charaCount);
        }
    } 

}