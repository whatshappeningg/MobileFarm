using UnityEngine;
using TMPro;

public class UIMoneyController : MonoBehaviour
{
	#region Fields
	private TMP_Text _moneyText;

	#endregion

	#region Unity Callbacks
	void Awake()
	{
		_moneyText = GetComponentInChildren<TMP_Text>();
	}

	#endregion

	#region Public Methods
	public void UpdateMoneyDisplay(int _currentMoney)
	{
		_moneyText.text = _currentMoney.ToString();
	}

	#endregion

}