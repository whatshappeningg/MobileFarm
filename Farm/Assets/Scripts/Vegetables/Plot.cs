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
	[Header("Particles")]
	[SerializeField] private ParticleSystem _wateringParticleSystem;
	[SerializeField] private ParticleSystem _fertilizerParticleSystem;
	private GameController _gameController;
	private GameObject _plantedVegetable;
	private ToggleSelectionManager _toggleSelectionManager;
	private PurchaseToggle _currentSelectedPurchaseButton;

	#endregion

	#region Unity Callbacks
	void Awake()
	{
		CurrentState = PlotState.Empty;
		PlotButton = GetComponent<Button>();

		_toggleSelectionManager = FindObjectOfType<ToggleSelectionManager>();
		_gameController = FindObjectOfType<GameController>();

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

		if (_currentSelectedPurchaseButton.TypeOfPurchase == PurchaseToggle.PurchaseType.Seed)
		{
			PlantVegetable(_currentSelectedPurchaseButton.PrefabToSpawn);
			_gameController.RemoveMoney(_currentSelectedPurchaseButton.Price);
			return;
		}
		if (_currentSelectedPurchaseButton.TypeOfPurchase == PurchaseToggle.PurchaseType.WateringCan)
		{
			WaterVegetable(_currentSelectedPurchaseButton);
			_gameController.RemoveMoney(_currentSelectedPurchaseButton.Price);
			return;
		}
		if (_currentSelectedPurchaseButton.TypeOfPurchase == PurchaseToggle.PurchaseType.Fertilizer)
		{
			UnblockPlot();
			_gameController.RemoveMoney(_currentSelectedPurchaseButton.Price);
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
	private void WaterVegetable(PurchaseToggle wateringCan)
	{
		_plantedVegetable.GetComponent<Vegetable>().Water(wateringCan.WateringTimeDecrease);
		_wateringParticleSystem.Emit(10);

	}
	private void UnblockPlot()
	{
		CurrentState = PlotState.Empty;
		PlotButton.interactable = false;
		BloquedButton.SetActive(false);
		_fertilizerParticleSystem.Emit(10);

	}
	private void RestartPlot(Vegetable harvestedVegetable)
	{
		CurrentState = PlotState.Empty;
		PlotButton.interactable = false;
	}

	#endregion

}