using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    /// <summary>
    /// �������
    /// </summary>
    [CreateAssetMenu(menuName = "LEO/Data Attack", fileName = "Data Attack")]
    public class DataAttack : ScriptableObject
    {
        [Header("�����O"), Range(0, 10000)]
        public float attack;
        [Header("�����O�B��"), Range(0, 100)]
        public float attackFloat;
    }

}
