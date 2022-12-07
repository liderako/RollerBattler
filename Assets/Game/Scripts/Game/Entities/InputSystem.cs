using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Scripts.Game
{
    public class InputSystem : MonoBehaviour
    {
        public Action<float,float> OnDirectionInputActionPlayer;
        [SerializeField] private Joystick joystick;

        public void Update()
        {
            if (OnDirectionInputActionPlayer != null)
            {
                OnDirectionInputActionPlayer(joystick.Horizontal, joystick.Vertical);
            }
            // if (GameManager.Instance.state == GameState.IN_GAME)
            // {
            //     if (OnDirectionInputEventPlayer != null)
            //     {
            //         OnDirectionInputEventPlayer(variableJoystick.Horizontal, variableJoystick.Vertical);
            //         if (Input.GetMouseButtonUp(0))
            //         {
            //             OnDirectionInputEventPlayer(0, 0);
            //         }
            //     }
            // }
            // else if (GameManager.Instance.state == GameState.GAME_OVER && LevelManager.Instance != null)
            // {
            //     if (Input.GetMouseButtonDown(0))
            //     {
            //         Destroy(GameManager.Instance.gameObject);
            //         LevelManager.Instance.LoadCurrentLevel();
            //     }
            // }
            // else if (GameManager.Instance.state == GameState.FINISH)
            // {
            //     if (Input.GetMouseButtonDown(0))
            //     {
            //         StartCoroutine(Wait());
            //         enabled = false;
            //     }
            // }
            // else if (Input.GetMouseButtonDown(0) && GameManager.Instance.state == GameState.MENU_TO_GAME)
            // {
            //     GameManager.Instance.ChangeState(GameState.IN_GAME);
            // }
        }
        
            // private IEnumerator Wait()
            // {
            //     yield return new WaitForSeconds(1f);
            //     Destroy(GameManager.Instance.gameObject);
            //     LevelManager.Instance.LoadCurrentLevel();
            // }
    }
}