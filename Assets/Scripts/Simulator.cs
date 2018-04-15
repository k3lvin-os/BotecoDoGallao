using BotecoDoGallao.Enumerations;
using BotecoDoGallao.TransferObjects;
using BotecoDoGallao.Util;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BotecoDoGallao
{
    public class Simulator : MonoBehaviour
    {
        private GameObject _mixMenu;
        private GameObject _sodaMenu;
        private GameObject _advancedResultsMenu;
        private Mixer _cokeMixer;
        private Mixer _pepsiMixer;
        private Mixer _rumMixer;
        private Mixer _iceCubesMixer;
        private Text _tasteLbl;
        private Text _priceLbl;
        private Text _strongCokeLbl;
        private Text _softCokeLbl;
        private Text _weakCokeLbl;
        private Text _strongPepsiLbl;
        private Text _softPepsiLbl;
        private Text _weakPepsiLbl;
        private Text _strongRumLbl;
        private Text _softRumLbl;
        private Text _weakRumLbl;
        private Text _iceCubesLbl;
        private Text _strongLbl;
        private Text _softLbl;
        private Text _weakLbl;
        private Text _tasteLbl2;
        private Text _priceLbl2;
        private Text _isCubaLivreLbl;
        private Text _isCubaLivreLbl2;
        private Button _advancedResultsBtn;
        private DrinkTO _drinkTo;
        private FuzzyPropertiesTO _fuzzyPropertiesTo;
        private DefuzzyPropertiesTO _defuzzyPropertiesTo;

        public void Start()
        {
            _mixMenu =
                SceneManager.GetActiveScene()
                .GetRootGameObjects()[0].transform.Find("Canvas")
                .Find("MixMenu").gameObject;
            _sodaMenu =
                SceneManager.GetActiveScene()
                    .GetRootGameObjects()[0].transform.Find("Canvas")
                    .Find("SodaMenu").gameObject;
            _advancedResultsMenu =
                SceneManager.GetActiveScene()
                    .GetRootGameObjects()[0].transform.Find("Canvas")
                    .Find("AdvancedResultsMenu").gameObject;
            _cokeMixer =
                new Mixer(_mixMenu.transform.Find("CokeMixer").gameObject, this);
            _pepsiMixer =
                new Mixer(_mixMenu.transform.Find("PepsiMixer").gameObject, this);
            _iceCubesMixer =
                new Mixer(_mixMenu.transform.Find("IceCubesMixer").gameObject, this);
            _rumMixer =
                new Mixer(_mixMenu.transform.Find("RumMixer").gameObject, this);
            _tasteLbl
                = _mixMenu.transform.Find("TasteLbl").gameObject.GetComponent<Text>();
            _priceLbl
                = _mixMenu.transform.Find("PriceLbl").gameObject.GetComponent<Text>();
            _advancedResultsBtn
                = _mixMenu.transform.Find("AdvancedResultsBtn").gameObject.GetComponent<Button>();
            _strongCokeLbl
                = _advancedResultsMenu.transform.Find("StrongCokeLbl").gameObject.GetComponent<Text>();
            _softCokeLbl
                = _advancedResultsMenu.transform.Find("SoftCokeLbl").gameObject.GetComponent<Text>();
            _weakCokeLbl
                = _advancedResultsMenu.transform.Find("WeakCokeLbl").gameObject.GetComponent<Text>();
            _strongPepsiLbl
                = _advancedResultsMenu.transform.Find("StrongPepsiLbl").gameObject.GetComponent<Text>();
            _softPepsiLbl
                = _advancedResultsMenu.transform.Find("SoftPepsiLbl").gameObject.GetComponent<Text>();
            _weakPepsiLbl
                = _advancedResultsMenu.transform.Find("WeakPepsiLbl").gameObject.GetComponent<Text>();
            _strongRumLbl
                = _advancedResultsMenu.transform.Find("StrongRumLbl").gameObject.GetComponent<Text>();
            _softRumLbl
                = _advancedResultsMenu.transform.Find("SoftRumLbl").gameObject.GetComponent<Text>();
            _weakRumLbl
                = _advancedResultsMenu.transform.Find("WeakRumLbl").gameObject.GetComponent<Text>();
            _iceCubesLbl
                = _advancedResultsMenu.transform.Find("IceCubesLbl").gameObject.GetComponent<Text>();
            _strongLbl
                = _advancedResultsMenu.transform.Find("StrongLbl").gameObject.GetComponent<Text>();
            _softLbl
                = _advancedResultsMenu.transform.Find("SoftLbl").gameObject.GetComponent<Text>();
            _weakLbl
                = _advancedResultsMenu.transform.Find("WeakLbl").gameObject.GetComponent<Text>();
            _tasteLbl2
                = _advancedResultsMenu.transform.Find("TasteLbl2").gameObject.GetComponent<Text>();
            _priceLbl2
                = _advancedResultsMenu.transform.Find("PriceLbl2").gameObject.GetComponent<Text>();
            _isCubaLivreLbl
                = _mixMenu.transform.Find("IsCubaLivreLbl").gameObject.GetComponent<Text>();
            _isCubaLivreLbl2
                = _advancedResultsMenu.transform.Find("IsCubaLivreLbl2").gameObject.GetComponent<Text>();
            _drinkTo = new DrinkTO();
            _fuzzyPropertiesTo = new FuzzyPropertiesTO();
            _defuzzyPropertiesTo = new DefuzzyPropertiesTO();

        }

        public void ChooseSoda(int soda)
        {
            _drinkTo.Soda = (Soda)soda;
            Debug.Assert(_drinkTo.Soda == Soda.Pepsi || _drinkTo.Soda == Soda.Coke);
            StartCoroutine(this.CallbackCoroutine(() =>
            {
                _mixMenu.SetActive(true);
                _sodaMenu.SetActive(false);
                _cokeMixer.SetActive(_drinkTo.Soda == Soda.Coke);
                _pepsiMixer.SetActive(_drinkTo.Soda == Soda.Pepsi);
                _pepsiMixer.SetValue(0f);
                _cokeMixer.SetValue(0f);
                _rumMixer.SetValue(0f);
                _iceCubesMixer.SetValue(0f);
                UpdateValues();
            }, 0.1f));
        }

        public void MenuMixer_BackBtn_OnClick()
        {
            StartCoroutine(this.CallbackCoroutine(() =>
            {
                _mixMenu.SetActive(false);
                _sodaMenu.SetActive(true);
            }, 0.1f));
        }

        public void MenuMixer_AdvancedResultsBtn_OnClick()
        {
            StartCoroutine(this.CallbackCoroutine(() =>
            {
                _mixMenu.SetActive(false);
                _advancedResultsMenu.SetActive(true);
                _strongCokeLbl.gameObject.SetActive(_drinkTo.Soda == Soda.Coke);
                _softCokeLbl.gameObject.SetActive(_drinkTo.Soda == Soda.Coke);
                _weakCokeLbl.gameObject.SetActive(_drinkTo.Soda == Soda.Coke);
                _strongPepsiLbl.gameObject.SetActive(_drinkTo.Soda == Soda.Pepsi);
                _softPepsiLbl.gameObject.SetActive(_drinkTo.Soda == Soda.Pepsi);
                _weakPepsiLbl.gameObject.SetActive(_drinkTo.Soda == Soda.Pepsi);
            }, 0.1f));
        }

        public void AdvancedReuslts_BackBtn_OnClick()
        {
            StartCoroutine(this.CallbackCoroutine(() =>
            {
                _mixMenu.SetActive(true);
                _advancedResultsMenu.SetActive(false);
            }, 0.1f));
        }

        public void UpdateValues()
        {
            if (_drinkTo.Soda == Soda.Coke)
                _drinkTo.Coke = _cokeMixer.GetValue();
            else
                _drinkTo.Pepsi = _pepsiMixer.GetValue();
            _drinkTo.Rum = _rumMixer.GetValue();
            _drinkTo.IceCubes = _iceCubesMixer.GetValue();
            Fuzzy.Fill(_drinkTo, _fuzzyPropertiesTo);
            Defuzzy.Fill(_drinkTo, _fuzzyPropertiesTo, _defuzzyPropertiesTo);
            _tasteLbl.text = string.Format("Paladar: {0}", Conversions.ToString(_defuzzyPropertiesTo.Taste));
            _priceLbl.text = string.Format("Preço: {0}", Conversions.ToPrice(_defuzzyPropertiesTo.Taste));
            _strongCokeLbl.text = "uCocaForte(x) = " + _fuzzyPropertiesTo.StrongCoke;
            _softCokeLbl.text = "uCocaSuave(x) = " + _fuzzyPropertiesTo.SoftCoke;
            _weakCokeLbl.text = "uCocaFraca(x) = " + _fuzzyPropertiesTo.WeakCoke;
            _strongPepsiLbl.text = "uPepsiForte(x) = " + _fuzzyPropertiesTo.StrongPepsi;
            _softPepsiLbl.text = "uPepsiSuave(x) =" + _fuzzyPropertiesTo.SoftPepsi;
            _weakPepsiLbl.text = "uPepsiFraca(x) = " + _fuzzyPropertiesTo.WeakPepsi;
            _strongRumLbl.text = "uRumForte(x) = " + _fuzzyPropertiesTo.StrongRum;
            _softRumLbl.text = "uRumSuave(x) = " + _fuzzyPropertiesTo.SoftRum;
            _weakRumLbl.text = "uRumFraco(x) = " + _fuzzyPropertiesTo.WeakRum;
            _iceCubesLbl.text = "uGelo(x) = " + _fuzzyPropertiesTo.IceCubes;
            _strongLbl.text = "Forte = " + _defuzzyPropertiesTo.Strong;
            _softLbl.text = "Suave = " + _defuzzyPropertiesTo.Soft;
            _weakLbl.text = "Fraco = " + _defuzzyPropertiesTo.Weak;
            _tasteLbl2.text = string.Format("Paladar: {0}", Conversions.ToString(_defuzzyPropertiesTo.Taste));
            _priceLbl2.text = string.Format("Preço: {0}", Conversions.ToPrice(_defuzzyPropertiesTo.Taste));
            if (_defuzzyPropertiesTo.IsCubaLivre)
            {
                _isCubaLivreLbl.text = "É CUBA LIVRE!";
                _isCubaLivreLbl2.text = "É CUBA LIVRE!";
            }
            else
            {
                _isCubaLivreLbl.text = "NÃO É CUBA LIVRE!";
                _isCubaLivreLbl2.text = "NÃO É CUBA LIVRE!";
            }
        }


    }
}

