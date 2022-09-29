using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace RoomEscape
{
    public class UI_GameCycle : MonoBehaviour
    {
        GameObject _ui_GameStart;
        GameObject _ui_ConfirmRestart;
        GameObject _ui_Restart;

        private void Start()
        {
            _ui_GameStart = transform.Find("UI_GameStart").gameObject;
            _ui_ConfirmRestart = transform.Find("UI_GameReStart/ConfirmRestart").gameObject;
            _ui_Restart = transform.Find("UI_GameReStart/Restart").gameObject;


            _ui_GameStart.SetActive(true);
            _ui_ConfirmRestart.SetActive(false);
            _ui_Restart.SetActive(false);
        }
        public void GameStart()
        {
            _ui_GameStart.SetActive(false);
            _ui_Restart.SetActive(true);
        }
        public void GameReStart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ConfirmationWindow(bool con)
        {
            _ui_ConfirmRestart.SetActive(con);
        }
        public void Intro()
        {
            
        }
    }
}
    
