using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    /// <summary>
    /// 攻擊資料
    /// </summary>
    [CreateAssetMenu(menuName = "LEO/Data Attack", fileName = "Data Attack")]
    public class DataAttack : ScriptableObject
    {
        [Header("攻擊力"), Range(0, 10000)]
        public float attack;
        [Header("攻擊力浮動"), Range(0, 100)]
        public float attackFloat;
    }

}
