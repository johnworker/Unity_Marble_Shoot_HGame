using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ǲ� �D�R�A API
/// API ���W�S�� static
/// </summary>
public class LearnAPINonStatic : MonoBehaviour
{
    public Transform transA;
    public Light lightA;

    private void Start()
    {
        // �D�R�A�ݩ� properties
        // 1.���o get
        // ����G
        // -�����O�������
        // -���骫��
        // -���s��ӹ��骫��

        // ���W��.�D�R�A�ݩʦW��
        print(" A ���󪺮y�СG" + transA.position);
        print("�O���C��G" + lightA.color);

        // 2.�]�w set
        // ���W��.�D�R�A�ݩʦW�� ���w ��;
        transA.position = new Vector3(1.7f, 0.5f, -10);
        lightA.color = new Color(1, 0, 0);
    }
}
