using UnityEngine;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]

public class Vegetable : MonoBehaviour
{
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
	public event Action<Vegetable> VegetableHarvested;

	#endregion

	#region Fields
	private Image _image;
	private Button _button;
	private ParticleSystem _harvestEffect;
	private GameController _gameController;
	[SerializeField] private int _states;
	[SerializeField] private int _currentState;
	[SerializeField] private Sprite[] _spritesStates;
	[SerializeField] private float _currentCooldownTime = 5f;
	private float _stateCooldownTime;
	private float _totalCooldownTime;
	[SerializeField] private int _reward;


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
		_gameController = FindObjectOfType<GameController>();
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
		_gameController.AddMoney(_reward);
		_harvestEffect.Emit(10);
		VegetableHarvested?.Invoke(this);
		Destroy(gameObject, _harvestEffect.main.duration);
	}

	#endregion

}