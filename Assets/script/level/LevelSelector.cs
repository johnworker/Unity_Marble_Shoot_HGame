using UnityEngine;
using UnityEngine.UI;

namespace LEO
{
    public class LevelSelector : MonoBehaviour
    {
        // 取公開腳本 場景淡入淡出
        public SceneFader fader;

        public Button[] levelButtons;

        private void Start()
        {
            int levelReached = PlayerPrefs.GetInt("levelReached", 1);
            for (int i = 0; i < levelButtons.Length; i++)
            {
                if(i + 1 > levelReached)
                levelButtons[i].interactable = false;
            }
        }

        // 選擇器  定義函數為字串 levelName
        public void Select(string levelName)
        {
            fader.FadeTo(levelName);
        }

        /*
         
        selectedLevel = level;
        SceneManager.LoadScene("Level" + level);
        
        public void SelectLevelOne()
        {
            selectedLevel = "Level1";
            levelText.text = "Level 1 Selected";
        }

        public void LoadSelectedLevel()
        {
            SceneManager.LoadScene(selectedLevel);
        }
        */
    }
}