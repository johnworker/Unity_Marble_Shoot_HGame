using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEO
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// 關卡設定
        /// </summary>
        public string nextLevel = "Level2";
        public int levelToUnlock = 2;

        [SerializeField]
        private SceneFader sceneFader;


        /// <summary>
        /// 關卡勝利
        /// </summary>
        public void WinLevel()
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
            sceneFader.FadeTo(nextLevel);
        }

    }
}
