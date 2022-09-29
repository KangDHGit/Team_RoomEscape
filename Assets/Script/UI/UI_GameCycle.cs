using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace RoomEscape
{
    public class UI_GameCycle : MonoBehaviour
    {
        GameObject _ui_GameStart;
        GameObject _ui_ConfirmRestart;
        GameObject _ui_Restart;
        GameObject _ui_Intro;
        GameObject _ui_Black;
        Text _introTxt;
        string _intro;

        bool _isIntroEnd;

        private void Start()
        {
            _ui_GameStart = transform.Find("UI_GameStart").gameObject;
            _ui_ConfirmRestart = transform.Find("UI_GameReStart/ConfirmRestart").gameObject;
            _ui_Restart = transform.Find("UI_GameReStart/Restart").gameObject;
            _ui_Intro = transform.Find("UI_Intro").gameObject;
            _ui_Black = transform.Find("UI_Black").gameObject;

            _ui_GameStart.SetActive(true);
            _ui_ConfirmRestart.SetActive(false);
            _ui_Restart.SetActive(false);
            _ui_Intro.SetActive(false);
            _ui_Black.SetActive(false);

            _isIntroEnd = false;


            _introTxt = transform.Find("UI_Intro/IntroTxt").GetComponent<Text>();
            _intro = _introTxt.text;
            _introTxt.text = "";
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                if (_isIntroEnd == true)
                {
                    IntroSet(false);
                }
            }
        }

            
        public void GameStart()
        {
            _ui_GameStart.SetActive(false);

            StartCoroutine(PlayIntro());
        }
        public void GameReStart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ConfirmationWindow(bool con)
        {
            _ui_ConfirmRestart.SetActive(con);
        }

        void IntroSet(bool set)
        {
            _ui_Black.SetActive(set);
            _ui_Intro.SetActive(set);
            _ui_Restart.SetActive(!set);
        }

        IEnumerator PlayIntro()
        {
            IntroSet(true);

            foreach (char c in _intro)
            {
                _introTxt.text += c;
                yield return new WaitForSeconds(0.1f);
            }

            _isIntroEnd = true;
        }

    }
}
    
