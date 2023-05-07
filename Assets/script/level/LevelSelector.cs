using UnityEngine;

namespace LEO
{
    public class LevelSelector : MonoBehaviour
    {
        public SceneFader fader;

        // 選擇器  定義函數為字串 levelName
        public void Select(string levelName)
        {
            fader.FadeTo(levelName);
        }
    }
}