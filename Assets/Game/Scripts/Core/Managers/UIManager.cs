using System.Collections;
using System.Collections.Generic;
using CoreGame.Utils.Template;
using UnityEngine;

namespace CoreGame.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private GameObject panelMenu;
        [SerializeField] private GameObject panelGameOverMenu;
        [SerializeField] private GameObject panelGamePlayMenu;
        [SerializeField] private GameObject panelVictoryMenu;
        private void Start()
        {
            GameManager.Instance.OnGameEvent += OnHandleGameEvent;
            GameManager.Instance.OnFinishEvent += OnHandleFinishGameEvent;
            GameManager.Instance.OnGameEvent += OnHandleGameOverEvent;
        }

        private void OnHandleGameEvent()
        {
            panelMenu.SetActive(false);
            panelGamePlayMenu.SetActive(true);
        }
        
        private void OnHandleFinishGameEvent()
        {
            panelVictoryMenu.SetActive(true);
            panelGamePlayMenu.SetActive(false);
        }
        
        private void OnHandleGameOverEvent()
        {
            panelGameOverMenu.SetActive(true);
            panelGamePlayMenu.SetActive(false);
        }
    }
}