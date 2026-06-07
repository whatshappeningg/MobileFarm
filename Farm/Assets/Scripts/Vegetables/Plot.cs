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

	#endregion

	#region Unity Callbacks
	void Awake()
	{
		CurrentState = PlotState.Empty;
		PlotButton = GetComponent<Button>();
		// BloquedButton = GameObject.FindFirstObjectByType<BloquedPlot Image>().gameObject;
	}
	#endregion

	#region Public Methods
	public void PlantVegetable(GameObject vegetablePrefab)
	{
		CurrentState = PlotState.Planted;
		Instantiate(vegetablePrefab, transform.position, Quaternion.identity, transform);
		PlotButton.interactable = false;
	}

	#endregion

	#region Private Methods
	#endregion

}