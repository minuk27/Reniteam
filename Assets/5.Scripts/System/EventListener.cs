using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ �̺�Ʈ ����(��: �ʾ������� �� ����npc���� �߿��ϰ� ����� ���̶� �������� ������ �Ѿƿ��� ��������)
public enum EventType
{
    MapItemPickUp, KeyItemPickUp,
    Listen, ProvideInformation, Interrogate, STT

};
public interface EventListener
{
    public void OnEvent(EventType eventType);
}

