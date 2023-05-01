using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    /// <summary>
    /// �����t��
    /// </summary>
    public class SystemAttack : MonoBehaviour
    {
        [SerializeField, Header("�������")]
        private DataAttack dataAttack;

        /// <summary>
        /// �����ƭ�
        /// </summary>
        public float valueAttack;

        private void Awake()
        {
            // �����ƭ� = �����O + �d��(-�����O�B�ʡG+�����B��)
            // �Ҧp�G�����ƭ� = 100 + (-10, 10)�G�d�򸨦b 99 ~ 110
            valueAttack = dataAttack.attack +
                Random.Range(-dataAttack.attackFloat, dataAttack.attackFloat);

            valueAttack = Mathf.Floor(valueAttack);
        }
    }

}
