using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// ���d�]�w
        /// </summary>
        public string nextLevel = "Level2";
        public int levelToUnlock = 2;

        [SerializeField]
        private SceneFader sceneFader;


        /// <summary>
        /// ���d�ӧQ
        /// </summary>
        public void WinLevel()
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
            sceneFader.FadeTo(nextLevel);
        }

    }
}
