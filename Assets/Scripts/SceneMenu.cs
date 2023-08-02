using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneMenu : MonoBehaviour
{
    [SerializeField] private Image SleepingCatW;
    [SerializeField] private Image SleepingCatC;
    [SerializeField] private Image SleepingCatB;
    private List<Image> HiddenCats;
    [SerializeField] private Image SettingsText;
    [SerializeField] private Image CharacterText;

    [SerializeField] private GameObject CatMenu;
    [SerializeField] private Image CatSelectCheckIcon;
    [SerializeField] private Image SleepingCatWhite;
    [SerializeField] private Image SleepingCatCheese;
    [SerializeField] private Image SleepingCatBlack;
    [SerializeField] private TextMeshProUGUI CatSkillInfoText;
    private List<Image> Cats;

    [SerializeField] private GameObject Deploy;

    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private Button SettingExit;
    [SerializeField] private Image OpeningText;
    [SerializeField] private Image CreditText;
    [SerializeField] private Image ExitText;

    [SerializeField] private GameObject CreditScene;
    [SerializeField] private Button CreditSceneExit;

    [SerializeField] private GameObject Opening;
    [SerializeField] private Animation OpeningAnimation;

    private bool isCatMenuPopup = false;
    private bool isSettingPopup = false;
    // Start is called before the first frame update
    private void Awake()
    {
        HiddenCats = new List<Image>
        {
            SleepingCatW,
            SleepingCatC,
            SleepingCatB
        };
        Cats = new List<Image>
        {
            SleepingCatWhite,
            SleepingCatCheese,
            SleepingCatBlack
        };
        isCatMenuPopup = false;
        isSettingPopup = false;
    }
    void Start()
    {
        SetSleepingCatImage(GameManager.Instance.SelectedCat);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //자고있는 고양이에 연결
    public void OnCatMenuEnterEvent()
    {
        if (isCatMenuPopup)
        {
            CharacterText.gameObject.SetActive(false);
            return;
        }
        CharacterText.gameObject.SetActive(true);
    }
    //자고있는 고양이에 연결
    public void OnCatMenuExitEvent()
    {
        CharacterText.gameObject.SetActive(false);
    }
    //자고있는 고양이에 연결
    public void OnCatMenuClickEvent()
    {
        if (!isCatMenuPopup)
        {
            isCatMenuPopup = true;
            int cat = GameManager.Instance.SelectedCat;
            SetSkillInfoText(cat);
            SetSleepingCatImage(cat);
            SetCheckPosition(cat);
            CharacterText.gameObject.SetActive(false);
            CatMenu.SetActive(true);
        }
        else
        {
            //다시 눌러서 끄기
            isCatMenuPopup = false;
            CatMenu.SetActive(false);
        }
    }
    //메뉴창에 뜬 고양이에 연결
    public void OnSleepingCatsClickEvent(int cat)
    {
        GameManager.Instance.SelectedCat = cat;
        SetSleepingCatImage(cat);
        SetCheckPosition(cat);
    }
    private void SetCheckPosition(int cat)
    {
        CatSelectCheckIcon.GetComponent<RectTransform>().anchoredPosition
            = Cats[cat].transform.localPosition;
        CatSelectCheckIcon.gameObject.SetActive(true);
    }
    private void SetSleepingCatImage(int cat)
    {
        SleepingCatW.gameObject.SetActive(cat == 0);
        SleepingCatC.gameObject.SetActive(cat == 1);
        SleepingCatB.gameObject.SetActive(cat == 2);
    }
    private void SetSkillInfoText(int cat)
    {
        string text;
        switch (cat)
        {
            case 1:
                text = "WHITE SKILL";
                break;
            case 2:
                text = "CHEESE SKILL";
                break;
            case 3:
                text = "BLACK SKILL";
                break;
            default:
                text = "FUCK";
                break;
        }
        CatSkillInfoText.text = text;
    }

    //톱니바퀴에 연결
    public void OnSettingEnterEvent()
    {
        if (isSettingPopup)
        {
            SettingsText.gameObject.SetActive(false);
            return;
        }
        SettingsText.gameObject.SetActive(true);
    }
    public void OnSettingExitEvent()
    {
        SettingsText.gameObject.SetActive(false);
    }
    //톱니바퀴에 연결
    public void OnSettingClickEvent()
    {
        if (!isSettingPopup)
        {
            isSettingPopup = true;
            SettingsText.gameObject.SetActive(false);
            SettingsMenu.SetActive(true);
        }
    }
    //세팅메뉴 닫기버튼에 연결
    public void OnSettingExitClickEvent()
    {
        isSettingPopup = false;
        SettingsMenu.SetActive(false);

    }
}
