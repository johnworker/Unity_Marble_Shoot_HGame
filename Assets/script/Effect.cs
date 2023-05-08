using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    public class Effect : MonoBehaviour
    {
        public Transform monster;
        [SerializeField,Header("±ÛÂà³t«×")]
        private int monsterRotation = 5;

        void Update()
        {
            monster.Rotate(0, monsterRotation, 0);
        }


    }
}