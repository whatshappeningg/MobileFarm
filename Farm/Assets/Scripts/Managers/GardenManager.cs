using UnityEngine;
using System;
using UnityEngine.UI;

public class GardenManager : MonoBehaviour
{
	#region Properties

	#endregion

	#region Fields
	[SerializeField] private Plot[] _gardenPlots = new Plot[54];

	#endregion

	#region Unity Callbacks
	void Awake()
	{
		_gardenPlots = GetComponentsInChildren<Plot>();
	}
	void Start()
	{
		InitializeGardenPlots();
	}

	#endregion

	#region Public Methods
	public void SeedSelected()
	{
		ResetPlotButtons();
		foreach (Plot plot in _gardenPlots)
		{
			if (plot.CurrentState == PlotState.Empty)
			{
				plot.PlotButton.interactable = true;
			}
			if (plot.CurrentState == PlotState.Planted)
			{
				plot.PlotButton.interactable = false;
			}
			if (plot.CurrentState == PlotState.Bloqued)
			{
				plot.PlotButton.interactable = false;
				plot.BloquedButton.SetActive(true);
			}
		}
	}
	public void WateringCanSelected()
	{
		ResetPlotButtons();
		foreach (Plot plot in _gardenPlots)
		{
			if (plot.CurrentState == PlotState.Empty)
			{
				plot.PlotButton.interactable = false;
			}
			if (plot.CurrentState == PlotState.Planted)
			{
				plot.PlotButton.interactable = true;
			}
			if (plot.CurrentState == PlotState.Bloqued)
			{
				plot.PlotButton.interactable = false;
				plot.BloquedButton.SetActive(true);
			}
		}
	}

	public void FertilizerSelected()
	{
		ResetPlotButtons();
		foreach (Plot plot in _gardenPlots)
		{
			if (plot.CurrentState == PlotState.Empty)
			{
				plot.PlotButton.interactable = false;
			}
			if (plot.CurrentState == PlotState.Planted)
			{
				plot.PlotButton.interactable = false;
			}
			if (plot.CurrentState == PlotState.Bloqued)
			{
				plot.PlotButton.interactable = true;
				plot.BloquedButton.SetActive(true);
			}
		}
	}

	public void ResetSelection()
	{
		ResetPlotButtons();
	}

	#endregion

	#region Private Methods
	private void ResetPlotButtons()
	{
		foreach (Plot plot in _gardenPlots)
		{
			plot.PlotButton.interactable = false;
			plot.BloquedButton.SetActive(false);
		}
	}

	private void InitializeGardenPlots()
	{
		for (int i = 0; i < _gardenPlots.Length; i++)
		{
			_gardenPlots[i].PlotButton.interactable = false;

			if (i > 8)
				_gardenPlots[i].CurrentState = PlotState.Bloqued;
		}
	}

	#endregion

}