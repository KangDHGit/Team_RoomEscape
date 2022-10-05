using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace RoomEscape
{
    public class UI_GameCycle : MonoBehaviour
    {
        public static UI_GameCycle I;

        GameObject _ui_GameStart;
        GameObject _ui_ConfirmRestart;
        GameObject _ui_Restart;
        GameObject _ui_Intro;
        GameObject _ui_Black;

        GameObject _ui_GameEnd;

        Text _introTxt;
        string _intro;

        GameObject _introEnter;

        bool _isIntroEnd;
        bool _isSkip;

        public AudioSource _keyboardSound;

        void Awake()
        {
            I = this;
        }

        private void Start()
        {
            _ui_GameStart = transform.Find("UI_GameStart").gameObject;
            _ui_ConfirmRestart = transform.Find("UI_GameReStart/ConfirmRestart").gameObject;
            _ui_Restart = transform.Find("UI_GameReStart/Restart").gameObject;
            _ui_Intro = transform.Find("UI_Intro").gameObject;
            _ui_Black = transform.Find("UI_Black").gameObject;
            _ui_GameEnd = transform.Find("UI_GameEnd").gameObject;

            _ui_GameStart.SetActive(true);
            _ui_ConfirmRestart.SetActive(false);
            _ui_Restart.SetActive(false);
            _ui_Intro.SetActive(false);
            _ui_Black.SetActive(false);
            _ui_GameEnd.SetActive(false);

            _isIntroEnd = false;
            _isSkip = false;

            _introTxt = transform.Find("UI_Intro/IntroTxt").GetComponent<Text>();
            _intro = _introTxt.text;
            _introTxt.text = "";

            _introEnter = transform.Find("UI_Intro/Enter").gameObject;
            _introEnter.SetActive(false);

            _keyboardSound = transform.Find("UI_Intro/IntroTxt").GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                _isSkip = true;
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

        public void GameEnd()
        {
            _ui_Restart.SetActive(false);
            _ui_GameEnd.SetActive(true);
        }

        IEnumerator PlayIntro()
        {
            IntroSet(true);
            _keyboardSound.Play();
            foreach (char c in _intro)
            {
                
                _introTxt.text += c;

                if (_isSkip == false)
                { 
                    yield return new WaitForSeconds(0.2f);
                }
            }

            
            _isIntroEnd = true;
            StartCoroutine(IntroEnter());
        }

        IEnumerator IntroEnter()
        {
            _keyboardSound.Stop();
            while (true)
            {
                if (_isIntroEnd == false)
                {
                    yield break;
                }
      
                _introEnter.SetActive(true);
                yield return new WaitForSeconds(0.5f);

                _introEnter.SetActive(false);
                yield return new WaitForSeconds(0.5f);

            }

        }

    }
}
    
