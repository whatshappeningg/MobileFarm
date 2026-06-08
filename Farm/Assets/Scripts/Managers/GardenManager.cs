using UnityEngine;
using System;
using UnityEngine.UI;

public class GardenManager : MonoBehaviour
{
	#region Properties
	public Plot[] GardenPlots { get; set; } = new Plot[54];

	#endregion

	#region Fields
	#endregion

	#region Unity Callbacks
	void Awake()
	{
		GardenPlots = FindObjectsOfType<Plot>();
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
		foreach (Plot plot in GardenPlots)
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
		foreach (Plot plot in GardenPlots)
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
		foreach (Plot plot in GardenPlots)
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
		foreach (Plot plot in GardenPlots)
		{
			plot.PlotButton.interactable = false;
			plot.BloquedButton.SetActive(false);
		}
	}

	private void InitializeGardenPlots()
	{
		for (int i = 0; i < GardenPlots.Length; i++)
		{
			GardenPlots[i].PlotButton.interactable = false;

			if (i < 45)
				GardenPlots[i].CurrentState = PlotState.Bloqued;
		}
	}

	#endregion

}