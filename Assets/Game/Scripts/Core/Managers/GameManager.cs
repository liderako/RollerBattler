using System.Collections;
using System.Collections.Generic;
using CoreGame.SO;
using UnityEngine;
using CoreGame.Utils.Template;

namespace CoreGame.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public delegate void GameEvent();
        public event GameEvent OnFinishEvent;
        public event GameEvent OnGameOverEvent;
        public event GameEvent OnGameEvent;
        public GameState state;

        public GameSettings Settings;

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
            Application.targetFrameRate = 60;
            ChangeState(GameState.MENU_TO_GAME);
        }

        public void ChangeState(GameState newState)
        {
            state = newState;
            if (newState == GameState.CONNECTION)
            {
            }
            else if (newState == GameState.INITIAL)
            {
            }
            else if (newState == GameState.IN_GAME)
            {
                CallGameEvent();
            }
            else if (newState == GameState.FINISH)
            {
                CallFinishEvent();
            }
            else if (newState == GameState.GAME_OVER)
            {
                CallGameOverEvent();
            }
            else if (newState == GameState.MENU_TO_GAME)
            {
            }
            else if (newState == GameState.READY_TO_GO)
            {
            }
        }

        private void CallFinishEvent()
        {
            if (OnFinishEvent != null)
            {
                OnFinishEvent();
                // TinySauce.OnGameFinished(_currentLvl.ToString(), true, 0);
#if UNITY_EDITOR
                Debug.Log("Finish");
#endif
            }
            else
            {
                Debug.LogError("OnFinishEvent doesn't have listeners");
            }
        }

        private void CallGameEvent()
        {
            if (OnGameEvent != null)
            {
                // TinySauce.OnGameStarted(_currentLvl.ToString());
#if UNITY_EDITOR
                Debug.Log("Game start");
#endif
                OnGameEvent();
            }
            else
            {
                Debug.LogError("OnGameEvent doesn't have listeners");
            }
        }
        
        private void CallGameOverEvent()
        {
            if (OnGameOverEvent != null)
            {
                // TinySauce.OnGameFinished(_currentLvl.ToString(), false, 0);
#if UNITY_EDITOR
                Debug.Log("Game over");
#endif
                OnGameOverEvent();
            }
            else
            {
                Debug.LogError("OnGameEvent doesn't have listeners");
            }
        }
    }
}
