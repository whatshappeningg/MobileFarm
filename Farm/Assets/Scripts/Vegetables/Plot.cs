using UnityEngine;
using System;
using UnityEngine.UI;

public class Plot : MonoBehaviour
{
	#region Properties
	public PlotState CurrentState { get; set; }
	#endregion

	#region Fields
	private Button _plotButton;

	#endregion

	#region Unity Callbacks
	void Awake()
	{
		CurrentState = PlotState.Empty;
		_plotButton = GetComponent<Button>();
	}

	void Update()
	{

	}
	#endregion

	#region Public Methods
	public void PlantVegetable(GameObject vegetablePrefab)
	{
		CurrentState = PlotState.Planted;
		Instantiate(vegetablePrefab, transform.position, Quaternion.identity, transform);
		_plotButton.interactable = false;

	}

	#endregion

	#region Private Methods
	#endregion

}