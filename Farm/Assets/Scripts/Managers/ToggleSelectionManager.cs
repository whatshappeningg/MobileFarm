using UnityEngine;
using System;
using System.Collections.Generic;

public class ToggleSelectionManager : MonoBehaviour
{
	#region Properties
	public PurchaseToggle CurrentSelectedButton { get; set; }

	#endregion

	#region Fields
	private GardenManager _gardenManager;
	#endregion

	#region Unity Callbacks
	void Awake()
	{
		_gardenManager = FindObjectOfType<GardenManager>();

	}

	void Update()
	{

	}
	#endregion

	#region Public Methods
	public void OnToggleSelected(PurchaseToggle purchaseButton)
	{
		CurrentSelectedButton = purchaseButton;
		if (CurrentSelectedButton.TypeOfPurchase == PurchaseToggle.PurchaseType.Seed)
		{
			_gardenManager.SeedSelected();
			return;
		}
		if (CurrentSelectedButton.TypeOfPurchase == PurchaseToggle.PurchaseType.Fertilizer)
		{
			_gardenManager.FertilizerSelected();
			return;
		}
		if (CurrentSelectedButton.TypeOfPurchase == PurchaseToggle.PurchaseType.WateringCan)
		{
			_gardenManager.WateringCanSelected();
			return;
		}
	}
	public void OnToggleDeselected()
	{
		_gardenManager.ResetSelection();
	}
	#endregion

	#region Private Methods
	#endregion

}