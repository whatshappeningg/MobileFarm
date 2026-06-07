using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class PurchaseButton : MonoBehaviour
{
	#region Properties
	public enum PurchaseType
	{
		Seed,
		Fertilizer,
		WateringCan
	}
	[field: SerializeField] public PurchaseType TypeOfPurchase;
	//public event Action OnToggleSelected;

	#endregion

	#region Fields
	private ToggleSelectionManager _toggleSelectionManager;
	private GameController _gameController;
	private Toggle _purchaseToggle;
	private TMP_Text _priceText;
	private int _negativePrice; // Este valor es negativo
	[SerializeField] private int _price;
	private Color _defaultColor;
	#endregion

	#region Unity Callbacks
	void Awake()
	{
		_toggleSelectionManager = FindObjectOfType<ToggleSelectionManager>();
		_gameController = FindObjectOfType<GameController>();
		_purchaseToggle = GetComponentInChildren<Toggle>();
		_priceText = GetComponentInChildren<TMP_Text>();

		_purchaseToggle.onValueChanged.AddListener(ToggleSelected);
		_negativePrice = -_price;

	}

	void Start()
	{
		_price = int.Parse(_priceText.text);
		_defaultColor = _priceText.color;

	}

	void Update()
	{
		if (_gameController.Money < _price)
			OnCantPurchase();
		else
			OnCanPurchase();

		// if (_purchaseToggle.isOn)
		// {
		// 	ToggleSelected();
		// 	_purchaseToggle.isOn = false; // Resetea el toggle después de la compra
		// }
	}
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	private void OnCantPurchase()
	{
		_priceText.color = Color.red;
		_purchaseToggle.interactable = false;

	}
	private void OnCanPurchase()
	{
		_priceText.color = _defaultColor;
		_purchaseToggle.interactable = true;

	}
	private void ToggleSelected(bool isOn)
	{
		//_gameController.Money += _negativePrice;
		//OnToggleSelected?.Invoke(); // Envía TypeOfPurchase
		if (isOn)
			_toggleSelectionManager.OnToggleSelected(this);
		else
			_toggleSelectionManager.OnToggleDeselected();
		//Debug.Log($"{TypeOfPurchase} toggle selected");

	}
	#endregion

}