using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Button))]

public class AnimalInteraction : MonoBehaviour
{
	#region Fields
	private Button _interactionButton;
	private GameObject _emoji;

	#endregion

	#region Unity Callbacks
	void Awake()
	{
		_interactionButton = GetComponent<Button>();
		_emoji = transform.GetChild(0).gameObject;
	}
	void Start()
	{
		_interactionButton.onClick.AddListener(OnButtonClicked);
	}

	#endregion

	#region Private Methods
	private void OnButtonClicked()
	{
		Debug.Log("Animal interacted with!");
		_emoji.SetActive(true);
		_emoji.transform.localPosition = new Vector2(0.01f, 0.15f);

		Sequence sequence = DOTween.Sequence();
		sequence.Append(_emoji.transform.DOMoveY(_emoji.transform.position.y + 0.2f, 0.5f));
		sequence.AppendInterval(0.3f);
		sequence.OnComplete(() => _emoji.SetActive(false));
	}

	#endregion

}