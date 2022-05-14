using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Controller
{
    public class InputController : MonoBehaviour
    {
        private GameController _gameController;

        private void Start()
        {
            _gameController = GameController.Instance;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
            }
            if (Input.GetKey(KeyCode.S))
            {
            }
            if (Input.GetKey(KeyCode.A))
            {
            }
            if (Input.GetKey(KeyCode.D))
            {
            }
            if (Input.GetKey(KeyCode.Space))
            {
            }
            if (Input.GetKey(KeyCode.E))
            {
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
               LevelController controller = Camera.main.GetComponent<LevelController>();
               if (controller.IsPaused())
               {
                   controller.EndPause();
                   Time.timeScale = 1.0F;
               }
               else
               {
                   controller.Pause();
                   Time.timeScale = 0.0F;
               }
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                GameController.Instance.ToogleBackgroundMusic();
            }
            if (Input.GetKeyDown(KeyCode.Escape) && Input.GetKeyDown(KeyCode.LeftShift))
            {
                EditorApplication.ExitPlaymode();
                Application.Quit();
            }
        }
    }
    
}
