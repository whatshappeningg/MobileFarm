using UnityEngine;
using System;
using System.Collections.Generic;

public class ToggleSelectionManager : MonoBehaviour
{
	#region Properties
	public PurchaseButton CurrentSelectedButton { get; set; }

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
	public void OnToggleSelected(PurchaseButton purchaseButton)
	{
		CurrentSelectedButton = purchaseButton;
		if (CurrentSelectedButton.TypeOfPurchase == PurchaseButton.PurchaseType.Seed)
		{
			_gardenManager.SeedSelected();
			return;
		}
		if (CurrentSelectedButton.TypeOfPurchase == PurchaseButton.PurchaseType.Fertilizer)
		{
			_gardenManager.FertilizerSelected();
			return;
		}
		if (CurrentSelectedButton.TypeOfPurchase == PurchaseButton.PurchaseType.WateringCan)
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