using System.Collections;
using System.Collections.Generic;
using CoreGame.SO;
using UnityEngine;
using UnityEngine.SceneManagement;
using CoreGame.Utils.Template;

namespace CoreGame.Managers
{
    public class LevelManager : Singleton<LevelManager>
    {
        // data
        [SerializeField] private int _currentLevel;
        [SerializeField] private int _currentIndexLevel;

        // settings
        private string[] _listLevels;
        private int _maxNumberLevel;
        private int _minNumberLevel;
        
        protected override void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            if (PlayerPrefs.GetInt("lvl", 0) == 0)
            {
                PlayerPrefs.SetInt("lvl", 0);
                PlayerPrefs.SetInt("prevlvl", 0);
                PlayerPrefs.Save();
                _currentLevel = 0;
            }
            _currentLevel = PlayerPrefs.GetInt("lvl");
            UpdateIndexLevel();
        }
        
        public void LoadNextLevelInList()
        {
            LoadLevelByName(_listLevels[_currentIndexLevel]);
        }
        
        public void LoadLevelByName(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        
        public void LoadLevelByIndex(int index)
        {
            SceneManager.LoadScene(index);
        }
        
        public void LoadCurrentLevel()
        {
            LoadLevelByName(_listLevels[_currentIndexLevel]);
        }
        
        public int GetCurrentLevelForUI()
        {
            return _currentLevel;
        }
        
        public int GetCurrentInxedLevel()
        {
            return _currentIndexLevel;
        }
        
        // метод для инциализации данных для левел менеджера через scritable object
        protected virtual void InitializeSettings(LevelSettings settings)
        {
            _listLevels = new string[settings.levelsName.Length];
            for (int i = 0; i < _listLevels.Length; i++)
            {
                _listLevels[i] = settings.levelsName[i];
            }
            _minNumberLevel = settings.minNumberLevel;
            _maxNumberLevel = settings.maxNumberLevel;
        }

        /************
        * Private methods
        ************/
        private void OnHandleFinishLevel()
        {
            _currentLevel++;
            PlayerPrefs.SetInt("lvl", _currentLevel);
            PlayerPrefs.Save();
            UpdateIndexLevel();
        }

        // Метод для поиска правильно индекса уровня
        private void UpdateIndexLevel()
        {
            if (_currentLevel >= _listLevels.Length)
            {
                int loadingLevel;
                int prevIndexLvl = PlayerPrefs.GetInt("prevlvl");
                do
                {
                    loadingLevel = Random.Range(_minNumberLevel, _maxNumberLevel);
                } while (loadingLevel == prevIndexLvl);

                PlayerPrefs.SetInt("prevlvl", loadingLevel);
                _currentIndexLevel = loadingLevel;
            }
            else
            {
                _currentIndexLevel = _currentLevel;
                PlayerPrefs.SetInt("prevlvl", _currentIndexLevel);
            }
            PlayerPrefs.Save();
        }
    }
}