using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //초기화 함수필요

    //이벤트리스너 저장할 딕셔너리
    private Dictionary<EventType, List<EventListener>> listeners = new Dictionary<EventType, List<EventListener>>();

    //이벤트리스너 추가
    public void AddListeners(EventType eventType, EventListener listener)
    {
        List<EventListener> listenerList = null;

        if (listeners.TryGetValue(eventType, out listenerList))
        {
            listenerList.Add(listener);
            return;
        }

        listenerList = new List<EventListener>();
        listenerList.Add(listener);
        listeners.Add(eventType, listenerList);
    }

    //이벤트리스너에게 이벤트 알림
    public void EventPost(EventType eventType)
    {
        List<EventListener> listenerList = null;

        if (!listeners.TryGetValue(eventType, out listenerList))
            return;

        for (int i = 0; i < listenerList.Count; i++)
        {
            if (!listenerList[i].Equals(null))
                listenerList[i].OnEvent(eventType);
        }
    }

    //이벤트 삭제
    public void RemoveEvent(EventType eventType)
    {
        listeners.Remove(eventType);
    }

    //씬전환시 호출되며 딕셔너리에 모든 리스너를 삭제한다.
    public void AllRemove()
    {
        listeners.Clear();
    }
}
