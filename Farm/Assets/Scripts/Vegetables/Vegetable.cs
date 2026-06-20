using UnityEngine;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]


public class Vegetable : MonoBehaviour
{
	#region Enums
	public enum VegetableType
	{
		Carrot,
		Tomato,
		Corn,
		Apple
	}

	#endregion

	#region Properties
	public float TotalCooldownTime
	{
		get { return _totalCooldownTime; }
		set
		{
			if (value <= 0)
			{
				_totalCooldownTime = 0;
				return;
			}
			_totalCooldownTime = value;

		}
	}
	public int Reward;
	public VegetableType Type;
	public event Action<Vegetable> VegetableHarvested;

	#endregion

	#region Fields
	private Image _image;
	private Button _button;
	private ParticleSystem _harvestEffect;
	private AudioSource _harvestingSound;
	private UITextController _uiRewardText;
	private MoneyController _gameController;
	[Header("Visualization")]
	private int _states;
	[SerializeField] private int _currentState;
	private float _totalCooldownTime;
	[SerializeField] private float _currentCooldownTime;
	[Header("Configurable")]
	[SerializeField] private float _stateCooldownTime;
	[SerializeField] private Sprite[] _spritesStates;


	#endregion

	#region Unity Callbacks
	void Awake()
	{
		_states = _spritesStates.Length;
		TotalCooldownTime = _stateCooldownTime * _states;
		_currentState = -1;

		_image = GetComponent<Image>();
		_button = GetComponent<Button>();
		_harvestEffect = GetComponentInChildren<ParticleSystem>();
		_harvestingSound = GetComponentInChildren<AudioSource>();
		_uiRewardText = GetComponentInChildren<UITextController>(true);
		_gameController = FindObjectOfType<MoneyController>();
		_button.enabled = false;
	}
	void Start()
	{
		_button.onClick.AddListener(Harvest);
		_image.sprite = _spritesStates[0];
	}

	void Update()
	{
		TotalCooldown();
		StateCooldown();

	}

	void OnDestroy()
	{
		VegetableHarvested = null;
	}
	#endregion

	#region Public Methods
	public void Water(int timeDecrease)
	{
		TotalCooldownTime -= timeDecrease;
		_currentCooldownTime -= timeDecrease;
		if (_currentCooldownTime < 0)
			_currentCooldownTime = 0;

		if (TotalCooldownTime < 0)
			TotalCooldownTime = 0;
	}

	#endregion

	#region Private Methods
	private void TotalCooldown()
	{
		TotalCooldownTime -= Time.deltaTime;

	}
	private void StateCooldown()
	{
		if (_currentCooldownTime > 0)
		{
			_currentCooldownTime -= Time.deltaTime;
			return;
		}
		if (_currentCooldownTime <= 0)
		{
			ChangeState();
			return;
		}
	}
	private void ChangeState()
	{
		if (_currentState < _states - 1)
		{
			_currentState++;
			_image.sprite = _spritesStates[_currentState];
			_currentCooldownTime = _stateCooldownTime;
			StateCooldown();
			return;
		}
		if (_currentState == _states - 1)
		{
			_button.enabled = true;
			return;
		}
	}

	private void Harvest()
	{
		VegetableCount();

		_gameController.AddMoney(Reward);
		_uiRewardText.gameObject.SetActive(true);
		_harvestEffect.Emit(10);
		_harvestingSound.Play();
		VegetableHarvested?.Invoke(this);
		Destroy(gameObject, _harvestEffect.main.duration);
	}

	private void VegetableCount()
	{
		switch (Type)
		{
			case VegetableType.Carrot:
				AchivementsManager.CarrotsHarvested++;
				break;
			case VegetableType.Tomato:
				AchivementsManager.TomatoesHarvested++;
				break;
			case VegetableType.Corn:
				AchivementsManager.CornHarvested++;
				break;
			case VegetableType.Apple:
				AchivementsManager.ApplesHarvested++;
				break;
		}
	}

	#endregion

}