using System;
using UnityEngine;
using UnityEngine.UI;

namespace BotecoDoGallao
{
    public class Mixer
    {
        private readonly GameObject _gameObject;
        private readonly Slider _slider;
        private readonly InputField _inputField;
        private readonly Simulator _simulator;

        public Mixer(GameObject gameObject, Simulator simulator)
        {
            _simulator = simulator;
            _gameObject = gameObject;
            _slider = _gameObject.transform.Find("Slider").gameObject.GetComponent<Slider>();
            _inputField = _gameObject.transform.Find("InputField").gameObject.GetComponent<InputField>();
            _slider.onValueChanged.AddListener(UpdateTextBox);
            _inputField.onValueChanged.AddListener(UpdateSliderAndTextBox);
        }

        public float GetValue()
        {
            return _slider.value;
        }

        public void SetValue(float value)
        {
            _slider.value = value;
        }

        public void SetActive(bool value)
        {
            _gameObject.SetActive(value);
        }

        private void UpdateTextBox(float value)
        {
            _inputField.text = Convert.ToInt32(value).ToString();
            _simulator.UpdateValues();
        }

        private void UpdateSliderAndTextBox(string text)
        {
            text = text.Replace("-", "");
            _inputField.text = text;
            try
            {
                _slider.value = float.Parse(text);
            }
            catch
            {
                _slider.value = 0f;
            }
            _simulator.UpdateValues();
        }





    }
}
