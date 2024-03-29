using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //�ʱ�ȭ �Լ��ʿ�

    //�̺�Ʈ������ ������ ��ųʸ�
    private Dictionary<EventType, List<EventListener>> listeners = new Dictionary<EventType, List<EventListener>>();

    //�̺�Ʈ������ �߰�
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

    //�̺�Ʈ�����ʿ��� �̺�Ʈ �˸�
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

    //�̺�Ʈ ����
    public void RemoveEvent(EventType eventType)
    {
        listeners.Remove(eventType);
    }

    //����ȯ�� ȣ��Ǹ� ��ųʸ��� ��� �����ʸ� �����Ѵ�.
    public void AllRemove()
    {
        listeners.Clear();
    }
}
