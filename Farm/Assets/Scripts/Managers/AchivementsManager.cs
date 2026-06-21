using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Canvas))]


public class AchivementsManager : MonoBehaviour
{
	#region Properties
	public static int CarrotsHarvested = 0;
	public static int TomatoesHarvested = 0;
	public static int CornHarvested = 0;
	public static int ApplesHarvested = 0;
	public static int MoneyEarned = 0;
	public static int TimesFertilized = 0;
	public static int TimesWatered = 0;

	#endregion

	#region Fields
	private AudioSource _achivementUnlockedSound;
	[SerializeField] private GameObject _01Achivement;
	private bool _01AchivementUnlocked = false;
	[SerializeField] private GameObject _02Achivement;
	private bool _02AchivementUnlocked = false;
	[SerializeField] private GameObject _03Achivement;
	private bool _03AchivementUnlocked = false;
	[SerializeField] private GameObject _04Achivement;
	private bool _04AchivementUnlocked = false;
	[SerializeField] private GameObject _05Achivement;
	private bool _05AchivementUnlocked = false;
	[SerializeField] private GameObject _06Achivement;
	private bool _06AchivementUnlocked = false;
	[SerializeField] private GameObject _07Achivement;
	private bool _07AchivementUnlocked = false;
	[SerializeField] private GameObject _08Achivement;
	private bool _08AchivementUnlocked = false;
	[SerializeField] private GameObject _09Achivement;
	private bool _09AchivementUnlocked = false;
	[SerializeField] private GameObject _10Achivement;
	private bool _10AchivementUnlocked = false;
	[SerializeField] private GameObject _11Achivement;
	private bool _11AchivementUnlocked = false;
	[SerializeField] private GameObject _12Achivement;
	private bool _12AchivementUnlocked = false;
	[SerializeField] private GameObject _13Achivement;
	private bool _13AchivementUnlocked = false;

	#endregion

	#region Unity Callbacks
	void Awake()
	{
		_achivementUnlockedSound = GetComponent<AudioSource>();
	}
	void Update()
	{
		CheckAchivements();
		print("Fertilizer: " + TimesFertilized);

	}

	#endregion

	#region Private Methods
	private void CheckAchivements()
	{
		// Planting Achivements
		if (!_01AchivementUnlocked && CarrotsHarvested == 10)
		{
			ShowAchivement(_01Achivement);
			_01AchivementUnlocked = true;
		}
		if (!_02AchivementUnlocked && TomatoesHarvested == 10)
		{
			ShowAchivement(_02Achivement);
			_02AchivementUnlocked = true;
		}
		if (!_03AchivementUnlocked && CornHarvested == 10)
		{
			ShowAchivement(_03Achivement);
			_03AchivementUnlocked = true;
		}
		if (!_04AchivementUnlocked && ApplesHarvested == 10)
		{
			ShowAchivement(_04Achivement);
			_04AchivementUnlocked = true;
		}
		// Money Achivements
		if (!_05AchivementUnlocked && MoneyEarned == 50)
		{
			ShowAchivement(_05Achivement);
			_05AchivementUnlocked = true;
		}
		if (!_06AchivementUnlocked && MoneyEarned == 100)
		{
			ShowAchivement(_06Achivement);
			_06AchivementUnlocked = true;
		}
		if (!_07AchivementUnlocked && MoneyEarned == 200)
		{
			ShowAchivement(_07Achivement);
			_07AchivementUnlocked = true;
		}
		if (!_08AchivementUnlocked && MoneyEarned == 500)
		{
			ShowAchivement(_08Achivement);
			_08AchivementUnlocked = true;
		}
		// Watering Achivements
		if (!_09AchivementUnlocked && TimesWatered == 5)
		{
			ShowAchivement(_09Achivement);
			_09AchivementUnlocked = true;
		}
		if (!_10AchivementUnlocked && TimesWatered == 50)
		{
			ShowAchivement(_10Achivement);
			_10AchivementUnlocked = true;
		}
		// Fertilizing Achivements
		if (!_11AchivementUnlocked && TimesFertilized == 1)
		{
			ShowAchivement(_11Achivement);
			_11AchivementUnlocked = true;
		}
		if (!_12AchivementUnlocked && TimesFertilized == 12)
		{
			ShowAchivement(_12Achivement);
			_12AchivementUnlocked = true;
		}
		if (!_13AchivementUnlocked && TimesFertilized == 44)
		{
			ShowAchivement(_13Achivement);
			_13AchivementUnlocked = true;
		}
	}
	private void ShowAchivement(GameObject achivement)
	{
		_achivementUnlockedSound.Play();
		GameObject ObjectAchivement = Instantiate(achivement, transform.position, Quaternion.identity, transform);

		Sequence sequence = DOTween.Sequence();
		sequence.Append(ObjectAchivement.transform.DOMoveY(ObjectAchivement.transform.position.y - 1, 1f));
		sequence.AppendInterval(4f);
		sequence.Append(ObjectAchivement.transform.DOMoveY(ObjectAchivement.transform.position.y + 1, 1f));
		sequence.OnComplete(() => Destroy(ObjectAchivement));
	}

	#endregion

}