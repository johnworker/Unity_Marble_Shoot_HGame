using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LEO
{
    /// <summary>
    /// 遊戲結束系統：勝利與失敗
    /// </summary>
    public class SystemFinal : MonoBehaviour
    {
        #region 資料
        /// <summary>
        /// 遊戲結束畫面底圖
        /// </summary>
        private CanvasGroup groupFinal;
        /// <summary>
        /// 遊戲結束小標題
        /// </summary>
        private TextMeshProUGUI textSubTitle;
        /// <summary>
        /// 選擇場景
        /// </summary>
        private Button btnchooseSceneLevel;
        /// <summary>
        /// 重新遊戲
        /// </summary>
        private Button btnReplay;
        /// <summary>
        /// 離開遊戲
        /// </summary>
        private Button btnQuit;

        public SceneFader fader;
        #endregion

        private void Awake()
        {
            groupFinal = GameObject.Find("遊戲結束畫面底圖").GetComponent<CanvasGroup>();
            textSubTitle = GameObject.Find("遊戲結束小標題").GetComponent<TextMeshProUGUI>();
            btnchooseSceneLevel = GameObject.Find("選擇場景").GetComponent<Button>();
            btnReplay = GameObject.Find("重新遊戲").GetComponent<Button>();
            btnQuit = GameObject.Find("離開遊戲").GetComponent<Button>();
            btnchooseSceneLevel.onClick.AddListener(ChooseSceneLevel);                          // 按下重新遊戲按鈕後 執行 Relay 方法
            btnReplay.onClick.AddListener(Replay);                          // 按下重新遊戲按鈕後 執行 Relay 方法
            btnQuit.onClick.AddListener(Quit);                              // 按下離開遊戲按鈕後 執行 Quit 方法
        }

        /// <summary>
        /// 顯示結束畫面並更新小標題
        /// </summary>
        /// <param name="subTitle">小標題文字</param>
        public void ShowFinalAndUndateSubTitle(string subTitle)
        {
            textSubTitle.text = subTitle;
            StartCoroutine(ShowFinal());
        }

        /// <summary>
        /// 顯示介面
        /// </summary>
        private IEnumerator ShowFinal()
        {
            for (int i = 0; i < 10; i++)
            {
                groupFinal.alpha += 0.1f;
                yield return new WaitForSeconds(0.03f);
            }

            groupFinal.interactable = true;     // 畫布群組.互動 = 啟動
            groupFinal.blocksRaycasts = true;   // 畫布群組.遮擋射線 = 啟動
        }

        private void ChooseSceneLevel()
        {
            // 按下按鈕跳到選擇場景
            fader.FadeTo("LevelSelect");
            StartCoroutine(LoadLevelAfterFade("LevelSelect"));
        }

        private IEnumerator LoadLevelAfterFade(string levelName)
        {
            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene(levelName);
        }
        private void Replay()
        {
            string nameCurrent = SceneManager.GetActiveScene().name;        // 取得當前場景名稱
            SceneManager.LoadScene(nameCurrent);                            // 場景管理.載入場景(名稱)
            
        }

        private void Quit()
        {
            Application.Quit();     // 應用程式.離開();   - 關閉遊戲，Unity 內無作用
        }
    }

}
