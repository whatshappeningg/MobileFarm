using UnityEngine;
using System;
using UnityEngine.UI;

public class Plot : MonoBehaviour
{
	#region Properties
	[field: SerializeField] public PlotState CurrentState { get; set; }
	public Button PlotButton { get; set; }
	[field: SerializeField] public GameObject BloquedButton { get; set; }
	#endregion

	#region Fields
	private GameObject _plantedVegetable;
	private ToggleSelectionManager _toggleSelectionManager;
	private PurchaseButton _currentSelectedPurchaseButton;

	#endregion

	#region Unity Callbacks
	void Awake()
	{
		CurrentState = PlotState.Empty;
		PlotButton = GetComponent<Button>();
		_toggleSelectionManager = FindObjectOfType<ToggleSelectionManager>();
	}
	void Start()
	{
		PlotButton.onClick.AddListener(OnPlotButtonClicked);

	}
	#endregion

	#region Public Methods
	public void OnPlotButtonClicked()
	{
		_currentSelectedPurchaseButton = _toggleSelectionManager.CurrentSelectedButton;

		if (_currentSelectedPurchaseButton == null)
			return;

		if (_currentSelectedPurchaseButton.TypeOfPurchase == PurchaseButton.PurchaseType.Seed)
		{
			PlantVegetable(_currentSelectedPurchaseButton.PrefabToSpawn);
			return;
		}
		if (_currentSelectedPurchaseButton.TypeOfPurchase == PurchaseButton.PurchaseType.WateringCan)
		{
			WaterVegetable(_currentSelectedPurchaseButton.WateringTimeDecrease);
			return;
		}
		if (_currentSelectedPurchaseButton.TypeOfPurchase == PurchaseButton.PurchaseType.Fertilizer)
		{
			UnblockPlot();
			return;
		}

	}

	#endregion

	#region Private Methods
	private void PlantVegetable(GameObject vegetablePrefab)
	{
		CurrentState = PlotState.Planted;
		_plantedVegetable = Instantiate(vegetablePrefab, transform.position, Quaternion.identity, transform);
		_plantedVegetable.transform.SetAsLastSibling();

		Vegetable vegetableComponent = _plantedVegetable.GetComponent<Vegetable>();
		vegetableComponent.VegetableHarvested += RestartPlot;

		PlotButton.interactable = false;
	}
	private void WaterVegetable(int timeDecrease)
	{
		_plantedVegetable.GetComponent<Vegetable>().Water(timeDecrease);
	}
	private void UnblockPlot()
	{
		CurrentState = PlotState.Empty;
		PlotButton.interactable = false;
		BloquedButton.SetActive(false);
	}
	private void RestartPlot(Vegetable harvestedVegetable)
	{
		CurrentState = PlotState.Empty;
		PlotButton.interactable = false;
	}

	#endregion

}