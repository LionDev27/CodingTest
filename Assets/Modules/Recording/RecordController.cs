using System.Collections.Generic;
using CodingTest.Recording.Actions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodingTest.Recording
{
    public struct RecordData
    {
        public string name;
        public float duration;
        //Datos de cada acción. Cada acción tiene su comportamiento y todas tienen un valor de tiempo para saber cuándo se ha hecho dicha acción.
        public Queue<BaseAction> actions;
    }

    public class RecordController : MonoBehaviour
    {
        [SerializeField] private RecordSerializer _serializer;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private GameObject _startButton, _stopButton;
        private float _timer;
        private bool _runTimer;
        private RecordData _currentRecord;

        private void Update()
        {
            if (!_runTimer) return;
            _timer += Time.deltaTime;
        }

        public void StartRecording()
        {
            if (_inputField.text == "") return;
            _currentRecord = new RecordData
            {
                name = _inputField.text
            };
            _startButton.SetActive(false);
            _stopButton.SetActive(true);
            _timer = 0;
            _runTimer = true;
        }

        public void StopRecording()
        {
            _runTimer = false;
            _startButton.SetActive(true);
            _stopButton.SetActive(false);
            _currentRecord.duration = _timer;
            _serializer.Save(_currentRecord);
        }

        public void AddAction(BaseAction action)
        {
            action._timeKey = _timer;
            _currentRecord.actions.Enqueue(action);
        }
    }
}