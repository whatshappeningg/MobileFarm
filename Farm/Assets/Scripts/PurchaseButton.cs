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
	public event Action OnButtonSelected;

	#endregion

	#region Fields
	private GameController _gameController;
	private Button _purchaseButton;
	private TMP_Text _priceText;
	[SerializeField] private int _price; // Este valor es negativo
	private int _absolutePrice;
	private Color _defaultColor;
	#endregion

	#region Unity Callbacks
	void Awake()
	{
		_gameController = FindObjectOfType<GameController>();
		_purchaseButton = GetComponentInChildren<Button>();
		_priceText = GetComponentInChildren<TMP_Text>();

		_purchaseButton.onClick.AddListener(ButtonSelected);
		_absolutePrice = Math.Abs(_price);

	}

	void Start()
	{
		_absolutePrice = int.Parse(_priceText.text);
		_defaultColor = _priceText.color;

	}

	void Update()
	{
		if (_gameController.Money < _absolutePrice)
			OnCantPurchase();
		else
			OnCanPurchase();

	}
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	private void OnCantPurchase()
	{
		_priceText.color = Color.red;
		_purchaseButton.interactable = false;

	}
	private void OnCanPurchase()
	{
		_priceText.color = _defaultColor;
		_purchaseButton.interactable = true;

	}
	private void ButtonSelected()
	{
		_gameController.Money -= _price;
		// OnButtonSelected?.Invoke(); // Envía TypeOfPurchase

	}
	#endregion

}