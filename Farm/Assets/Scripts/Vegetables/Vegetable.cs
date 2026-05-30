using UnityEngine;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]

public class Vegetable : MonoBehaviour
{
	#region Properties
	public PlotState State { get; set; }
	public int Reward { get; set; }
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
	public static event Action<Vegetable> ReadyToHarvest;

	#endregion

	#region Fields
	private Image _image;
	private Button _button;
	[SerializeField] private int _states;
	[SerializeField] private int _currentState;
	[SerializeField] private Sprite[] _spritesStates;
	[SerializeField] private float _currentCooldownTime = 5f;
	[SerializeField] private float _stateCooldownTime;
	[SerializeField] private float _totalCooldownTime;

	#endregion

	#region Unity Callbacks
	void Awake()
	{
		State = PlotState.Planted;

		_states = _spritesStates.Length;
		TotalCooldownTime = _stateCooldownTime * _states;
		_currentState = -1;

		_image = GetComponent<Image>();
		_button = GetComponent<Button>();
		_button.enabled = false;
	}
	void Start()
	{
		_image.sprite = _spritesStates[0];
	}

	void Update()
	{
		TotalCooldown();
		StateCooldown();

	}
	#endregion

	#region Public Methods
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
			State = PlotState.ReadyToHarvest;
			ReadyToHarvest?.Invoke(this);
			_button.enabled = true;
			return;
		}
	}

	#endregion

}