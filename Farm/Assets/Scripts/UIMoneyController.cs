using UnityEngine;
using System;
using TMPro;

public class UIMoneyController : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	private TMP_Text _moneyText;
	//[SerializeField] private int _currentMoney;

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
		Debug.Log("Updating money display: " + _currentMoney);
		_moneyText.text = _currentMoney.ToString();
	}

	#endregion

	#region Private Methods
	#endregion

}