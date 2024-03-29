using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//지정할 이벤트 종류(예: 맵아이템이 그 마을npc들이 중요하게 여기는 것이라 아이템을 먹으면 쫓아옴을 구현가능)
public enum EventType
{
    MapItemPickUp, KeyItemPickUp,
    Listen, ProvideInformation, Interrogate, STT

};
public interface EventListener
{
    public void OnEvent(EventType eventType);
}

