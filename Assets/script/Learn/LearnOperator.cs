using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnOperator : MonoBehaviour
{
    /// <summary>
    /// �ǲ߹B��l
    /// 1.�ƾǹB��l
    /// 2.����B��l
    /// 3.�޿�B��l
    /// </summary>
    private float a = 10;
    private float b = 3;

    private int c = 99;
    private int d = 1;

    private int diamond = 1;
    private int hp = 100;
    private void Start()
    {

        #region �ƾǹB��l
        // �[
        // ��
        // ��
        // ��
        // �l


        print("�[�k�G" + (a + b));     // 13
        print("��k�G" + (a - b));     // 7
        print("���k�G" + (a * b));     // 30
        print("���k�G" + (a / b));     // 3.3333
        print("�l�k�G" + (a % b));     // 1
        #endregion

        #region ����B��l
        // �p�� <
        // �j�� >
        // �p�󵥩� <=
        // �j�󵥩� >=
        // ������ !=
        // ���� ==

        //����B��l�����G�����L�ȡGtrue�Bfalse
        print("�p��G" + (c < d));     // false
        print("�p��G" + (c > d));     // true
        print("�p��G" + (c <= d));    // false
        print("�p��G" + (c >= d));    // true
        print("�p��G" + (c != d));    // true
        print("�p��G" + (c == d));    // false
        #endregion

        #region �޿�B��l
        // �޿�B��l�A�w�塞�L��
        // �åB && �G��ӥ��L�Ȧ��@�� false ���G�N�O false
        print("true && true �G" + (true && true));       // true
        print("true && false �G" + (true && false));     // false
        print("false && true �G" + (false && true));     // false
        print("false && false �G" + (false && false));   // false

        // �Ϊ� || �G��ӥ��L�Ȧ��@�� true ���G�N�O true
        print("true || true �G" + (true || true));       // true
        print("true || false �G" + (true || false));     // true
        print("false || true �G" + (false || true));     // true
        print("false || false �G" + (false || false));   // false

        #endregion

        // �C���d��
        // �ӧQ����G�_�� >= 3�� �åB ��q �j�� 0 �~��L��
        print("�O�_�L���G" + (diamond >= 3 && hp > 0));      //false

        // �A�˹B��l
        // �@�ΡG�N���L���ܬۤ�
        print("!true�G" + (!true));      // false
        print("!false�G" + (!false));      // true

    }
}
