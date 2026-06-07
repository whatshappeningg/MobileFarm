using UnityEngine;
using System;

public enum PlotState
{
	Empty,
	Bloqued,
	Planted,
	ReadyToHarvest
}
public class GameController : MonoBehaviour
{
	#region Properties

	public int Money
	{
		get { return _money; }
		set
		{
			if (value <= 0)
			{
				_money = 0;
				_uiMoneyController.UpdateMoneyDisplay(_money);
				return;
			}
			if (value > 0)
			{
				_money = value;
				_uiMoneyController.UpdateMoneyDisplay(_money);
				return;
			}

		}
	}

	#endregion

	#region Fields
	private UIMoneyController _uiMoneyController;

	[SerializeField] private int _money;

	#endregion

	#region Unity Callbacks
	void Awake()
	{
		_uiMoneyController = FindObjectOfType<UIMoneyController>();

		_uiMoneyController.UpdateMoneyDisplay(_money);
	}

	void Update()
	{

	}
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	#endregion

}