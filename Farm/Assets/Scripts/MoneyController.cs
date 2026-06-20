using UnityEngine;

public class MoneyController : MonoBehaviour
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
				AchivementsManager.MoneyEarned = _money;
				return;
			}
			if (value > 0)
			{
				_money = value;
				_uiMoneyController.UpdateMoneyDisplay(_money);
				AchivementsManager.MoneyEarned = _money;
				return;
			}

		}
	}

	#endregion

	#region Fields
	private UIMoneyController _uiMoneyController;

	private int _money;

	#endregion

	#region Unity Callbacks
	void Awake()
	{
		_uiMoneyController = FindObjectOfType<UIMoneyController>();

		Money = 2;

	}

	#endregion

	#region Public Methods
	public void AddMoney(int amount)
	{
		Money += amount;
	}
	public void RemoveMoney(int amount)
	{
		Money -= amount;
	}

	#endregion

	#region Private Methods
	#endregion

}