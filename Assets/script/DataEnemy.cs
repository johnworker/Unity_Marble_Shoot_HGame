using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{

    // ScriptableObject �}���ƪ���G�}�����e�ܦ������Ʀs��b project ��
    // �����f�t CreateAssetMenu

    [CreateAssetMenu(menuName = "LEO/Data Enemy", fileName = "Data Enemy")]
    public class DataEnemy : ScriptableObject
    {
        [Header("��q"), Range(0, 10000)]
        public float hp;
        [Header("�ˮ`"), Range(0, 10000)]
        public float damage;
        [Header("���������w�m��")]
        public GameObject goCoin;
        [Header("���������d��")]
        public Vector2Int v2CoinRange;

    }

}