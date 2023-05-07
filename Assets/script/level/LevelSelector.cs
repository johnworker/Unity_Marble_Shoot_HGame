using UnityEngine;
using UnityEngine.UI;

namespace LEO
{
    public class LevelSelector : MonoBehaviour
    {
        // �����}�}�� �����H�J�H�X
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

        // ��ܾ�  �w�q��Ƭ��r�� levelName
        public void Select(string levelName)
        {
            fader.FadeTo(levelName);
        }
    }
}