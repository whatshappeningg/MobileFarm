using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PurchaseToggle : MonoBehaviour
{
	#region Enums
	public enum PurchaseType
	{
		Seed,
		Fertilizer,
		WateringCan
	}

	#endregion

	#region Properties
	[field: SerializeField] public PurchaseType TypeOfPurchase;
	[field: SerializeField] public GameObject PrefabToSpawn;
	[field: SerializeField] public int WateringTimeDecrease; // Solo para regadera
	[SerializeField] public int Price { get; set; }

	#endregion

	#region Fields
	private ToggleSelectionManager _toggleSelectionManager;
	private MoneyController _moneyController;
	private Toggle _purchaseToggle;
	private TMP_Text _priceText;
	private Color _defaultColor;

	#endregion

	#region Unity Callbacks
	void Awake()
	{
		_toggleSelectionManager = FindObjectOfType<ToggleSelectionManager>();
		_moneyController = FindObjectOfType<MoneyController>();
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
		if (_moneyController.Money < Price)
			OnCantPurchase();
		else
			OnCanPurchase();
	}

	#endregion

	#region Private Methods
	private void OnCantPurchase()
	{
		_priceText.color = Color.red;
		_purchaseToggle.isOn = false;
		_purchaseToggle.interactable = false;

	}
	private void OnCanPurchase()
	{
		_priceText.color = _defaultColor;
		_purchaseToggle.interactable = true;

	}
	private void ToggleSelected(bool isOn)
	{
		if (isOn)
			_toggleSelectionManager.OnToggleSelected(this);
		else
			_toggleSelectionManager.OnToggleDeselected();

	}

	#endregion

}