using Comma.Global.SaveLoad;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Comma.Home.UI
{
    public class HomeUI : MonoBehaviour
    {
        [Header("Home Menu Buttons")]
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _newGameButton;
        [SerializeField] private Button _creditssButton;
        [SerializeField] private Button _quitButton;

        [Header("Transitions")]
        [SerializeField] private GameObject _transition;

        [Header("Scene Management")]
        [SerializeField] private string _gameplaySceneName = "Gameplay";
        
        [Header("Home Menu Pop Up")]
        [SerializeField] private GameObject _creditsPopUp;
        [SerializeField] private GameObject _warningNewGamePopUp;
        [SerializeField] private GameObject _warningQuitPopUp;

        private void Start()
        {
        }
        
        private void OnEnable()
        {
            _continueButton.onClick.AddListener(OnContinueButton);
            _newGameButton.onClick.AddListener(OnNewGameButton);
            _creditssButton.onClick.AddListener(OnCreditsButton);
            _quitButton.onClick.AddListener(OnQuitButton);
        }

        private void OnDisable()
        {
            RemoveAllButtonListeners();
        }
        private void RemoveAllButtonListeners()
        {
            _continueButton.onClick.RemoveAllListeners();
            _newGameButton.onClick.RemoveAllListeners();
            _creditssButton.onClick.RemoveAllListeners();
            _quitButton.onClick.RemoveAllListeners();
        }

        private void OnNewGameButton()
        {
            _transition.SetActive(true);
            SceneManager.LoadSceneAsync(_gameplaySceneName);
            //SceneManager.LoadScene(_gameplaySceneName);
        }
        private  void OnContinueButton()
        {
            _transition.SetActive(true);
            SceneManager.LoadSceneAsync(_gameplaySceneName);
        }
        private void OnCreditsButton()
        {
            _creditsPopUp.SetActive(true);
        }
        private void OnQuitButton()
        {
            _warningQuitPopUp.SetActive(true);
        }
    }
}