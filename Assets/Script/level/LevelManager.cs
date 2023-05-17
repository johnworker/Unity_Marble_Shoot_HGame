using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LEO
{
    public class LevelManager : MonoBehaviour
    {
        public Button[] difficultyButtons;

        private int selectedDifficulty;

        private void Start()
        {
            // 讀取玩家所選的難易度
            selectedDifficulty = PlayerPrefs.GetInt("SelectedDifficulty", 0);

            // 設置難易度按鈕的互動狀態
            for (int i = 0; i < difficultyButtons.Length; i++)
            {
                if (i == selectedDifficulty)
                {
                    // 玩家所選的難易度
                    difficultyButtons[i].interactable = false;
                }
                else
                {
                    // 其他難易度選項
                    difficultyButtons[i].interactable = true;
                }
            }
        }

        public void SetDifficulty(int difficultyIndex)
        {
            // 更新選擇的難易度
            selectedDifficulty = difficultyIndex;

            // 存儲選擇的難易度
            PlayerPrefs.SetInt("SelectedDifficulty", selectedDifficulty);

            // 設置難易度按鈕的互動狀態
            for (int i
    = 0; i < difficultyButtons.Length; i++)
            {
                if (i == selectedDifficulty)
                {
                    // 玩家所選的難易度
                    difficultyButtons[i].interactable = false;
                }
                else
                {
                    // 其他難易度選項
                    difficultyButtons[i].interactable = true;
                }

                // 根據難易度設置關卡參數或加載對應的關卡
                switch (selectedDifficulty)
                {
                    case 0:
                        // 簡單難度
                        // 設置關卡參數或加載簡單難度的關卡
                        break;
                    case 1:
                        // 中等難度
                        // 設置關卡參數或加載中等難度的關卡
                        break;
                    case 2:
                        // 困難難度
                        // 設置關卡參數或加載困難難度的關卡
                        break;
                }
            }
        }
    }
}
