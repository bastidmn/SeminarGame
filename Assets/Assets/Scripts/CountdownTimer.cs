using System;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class CountdownTimer : MonoBehaviour
    {
        private Text _countdownText;

        public float startingTimer =0.0F;
        private float _currentTimer;
    
        void Start ()
        {
            _countdownText = (Text) gameObject.GetComponent(typeof(Text));
            _currentTimer = startingTimer;
        }

        void Update()
        {
            _currentTimer += Time.deltaTime;
            
            int currentSeconds = Mathf.RoundToInt(_currentTimer);
            String displayText = _formatText(currentSeconds);
            if (_countdownText is { }) _countdownText.text = displayText;
        }
        
        public String GetTimerEndScore()
        {
            int endSeconds = Mathf.RoundToInt(_currentTimer);
            return _formatText(endSeconds);
        }

         private static String _formatText(int seconds)
        {
            int timerMinutes = seconds % 60;
            int timerSeconds = seconds / 60;
            String minuteString = timerMinutes < 10 ? "0" + timerMinutes : timerMinutes.ToString();
            String secondString = timerSeconds < 10 ? "0" + timerSeconds : timerSeconds.ToString();
            StringBuilder sb = new StringBuilder(5);
            sb.Append(secondString).Append(":").Append(minuteString);
            return sb.ToString();
        }
    }
}