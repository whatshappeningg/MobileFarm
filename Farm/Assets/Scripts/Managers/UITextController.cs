using UnityEngine;
using DG.Tweening;
using TMPro;

public class UITextController : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	private Vegetable _vegetable;
	private TMP_Text _moneyText;
	private int _reward;


	#endregion

	#region Unity Callbacks
	void Awake()
	{
		_vegetable = GetComponentInParent<Vegetable>();
		_moneyText = GetComponent<TMP_Text>();

		_reward = _vegetable.Reward;
		_moneyText.text = "+ " + _reward.ToString();

	}
	void Start()
	{
		MoveTextUp(_moneyText);

	}

	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	private void MoveTextUp(TMP_Text text)
	{
		text.transform.DOMoveY(text.transform.position.y + 1, 1f);

	}

	#endregion

}