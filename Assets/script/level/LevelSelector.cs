using UnityEngine;

namespace LEO
{
    public class LevelSelector : MonoBehaviour
    {
        public SceneFader fader;

        // ��ܾ�  �w�q��Ƭ��r�� levelName
        public void Select(string levelName)
        {
            fader.FadeTo(levelName);
        }
    }
}