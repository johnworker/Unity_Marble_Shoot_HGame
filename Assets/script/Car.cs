using UnityEngine;

//�T���Ź� �n�ܦ� ����
//1.�����W���C������
//2.�K�[���� Add Component
//3.��������O
public class Car : MonoBehaviour
{
    // �� ���y�k ��
    //�׹��� ������� ���ۭq�W�� ���w �� �����Ÿ�
    //�׹�����ƪ��s���v��

    //��j�򥻭׹���
    //���}�G���\�~���s���A��ܦb�ݩʭ��O
    //public
    //�p�H�G�����\�~���s���A��ܦb�ݩʭ��O(�w�]�ȡA�i�ٲ�)
    //private

    // 1. Unity �H�ݩʭ��O��Ƭ��D
    // 2. �٭��C#�{�������ȥ�����...>Reset

    //����ݩʻy�k
    //[�ݩʦW��(��)]
    // Tooltip ���ܰT��

    //���q
    [Range(1,50)]
    [Tooltip("�T�������q���O��")]
    public int weight = 3;
    //����
    [Header("�T��������"),Range(1,10)]
    public float hight = 4.2f;
    //�~�P
    [Header("�T�����~�P�W��")]
    public string brand = "���h";
    //�O�_���ѵ�
    [Header("�O�_���ѵ�")]
    [Tooltip("�]�w�T���O�_���ѵ�")]
    public bool hasSkyWindow = true;
}
