using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class PurchaseToggle : MonoBehaviour
{
	#region Properties
	public enum PurchaseType
	{
		Seed,
		Fertilizer,
		WateringCan
	}

	[field: SerializeField] public PurchaseType TypeOfPurchase;
	[field: SerializeField] public GameObject PrefabToSpawn;
	[field: SerializeField] public int WateringTimeDecrease; // Solo para regadera
	[SerializeField] public int Price { get; set; }


	#endregion

	#region Fields
	private ToggleSelectionManager _toggleSelectionManager;
	private GameController _gameController;
	private Toggle _purchaseToggle;
	private TMP_Text _priceText;
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

	}

	void Start()
	{
		Price = int.Parse(_priceText.text);
		_defaultColor = _priceText.color;

	}

	void Update()
	{
		if (_gameController.Money < Price)
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