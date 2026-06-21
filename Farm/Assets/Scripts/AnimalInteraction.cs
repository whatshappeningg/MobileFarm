using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Button))]

public class AnimalInteraction : MonoBehaviour
{
	#region Properties
	#endregion

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

	void Update()
	{

	}
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	private void OnButtonClicked()
	{
		Debug.Log("Animal interacted with!");
		_emoji.SetActive(true);

		Sequence sequence = DOTween.Sequence();
		sequence.Append(_emoji.transform.DOMoveY(_emoji.transform.position.y + 0.4f, 0.5f));
		sequence.AppendInterval(0.5f);
		sequence.OnComplete(() => _emoji.SetActive(false));

	}
	#endregion

}