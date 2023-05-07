using UnityEngine;

/// <summary>
/// �ǲ� �R�A API
/// �R�A static
/// </summary>
public class LearnAPIStatic : MonoBehaviour
{
    private void Start()
    {
        // �R�A�ݩ� static properties
        // 1.���o get
        // ���o�R�A�ݩʻy�k�G
        // ���O�W��.�R�A�ݩʦW��
        print("�H���ȡG" + Random.value);
        print("�ù��e�סG" + Screen.width);
        print("��P�v�G" + Mathf.PI);
        // 2.�]�w set (Read Only ����]�w)
        // �]�w�R�A�ݩʻy�k�G
        // ���O�W��.�R�A�ݩʦW�� ���w ��

        Screen.brightness = 0.5f;
        Cursor.visible = false;

        // �R�A��k static methods
        // 3.�ϥ�
        // ���O�W��.�R�A��k�W�� (�������޼�)
        float r = Random.Range(7.7f, 99.9f);
        print("�H�� 7.7 ~ 99.9 �ƭȡG" + r);
    }

    private void Update()
    {
        bool downA = Input.GetKeyDown("a");
        print("�O�_���UA�G" + downA);
    }
}
