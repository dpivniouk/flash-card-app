using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashCardPanel : MonoBehaviour
{
    public GameObject cardPanel;
    public GameObject flashCardPanel;
    public GameObject editCardPanel;
    public GameObject lessonPanel;

    public Text cardFrontText;
    public Text cardBackText;

    public Button cardFrontButton;
    public Button cardBackButton;

    public Button nextButton;
    public Button backButton;

    private Lesson lesson = new Lesson();
    private List<FlashCard> cardSet = new List<FlashCard>();

    private Dictionary<int, FlashCard> cardDict = new Dictionary<int, FlashCard>();

    private int currentIndex;
    private Animator animator;

    void Start()
    {
        nextButton.onClick.AddListener(() => ChangeCard(1));
        backButton.onClick.AddListener(() => ChangeCard(-1));

        cardFrontButton.onClick.AddListener(() => FlipCard());
        cardBackButton.onClick.AddListener(() => FlipCard());

        animator = cardPanel.GetComponent<Animator>();

    }

    void OnEnable()
    {
        if(DataManager.instance.savedSubjects.subjects[DataManager.instance.subjectIndex].lessons[DataManager.instance.lessonIndex].cardList.Count == 0)
        {
            this.gameObject.SetActive(false);
            lessonPanel.SetActive(true);
            return;
        }

        currentIndex = 0;
        lesson = DataManager.instance.savedSubjects.subjects[DataManager.instance.subjectIndex].lessons[DataManager.instance.lessonIndex];
        cardSet.Clear();
        cardDict.Clear();
        RandomizeCards();
        PopulateCard();

        cardPanel.transform.eulerAngles = new Vector3(0f, 0f, 0f);

        cardPanel.transform.Find("FrontPanel").gameObject.SetActive(true);
        cardPanel.transform.Find("BackPanel").gameObject.SetActive(false);

    }

    void OnDisable()
    {
        lesson = null;
    }

    void RandomizeCards()
    {        
        for(int i  = 0; i < lesson.cardList.Count; i++)
        {
            cardSet.Add(lesson.cardList[i]);
            cardDict.Add(i, lesson.cardList[i]);
        }

        for(int i = 0; i < cardSet.Count; i++)
        {
            FlashCard temp = cardSet[i];
            int randomIndex = Random.Range(i, cardSet.Count);
            cardSet[i] = cardSet[randomIndex];
            cardSet[randomIndex] = temp;
        }

    }

    void PopulateCard()
    {
        cardFrontText.text = cardSet[currentIndex].cardFrontText;
        cardBackText.text = cardSet[currentIndex].cardBackText;

    }

    void ChangeCard(int indexChange)
    {
        currentIndex = currentIndex + indexChange;

        cardPanel.transform.eulerAngles = new Vector3(0f, 0f, 0f);

        cardPanel.transform.Find("FrontPanel").gameObject.SetActive(true);
        cardPanel.transform.Find("BackPanel").gameObject.SetActive(false);

        if (currentIndex < 0)
        {
            currentIndex = cardSet.Count - 1;

        }
        else if (currentIndex >= cardSet.Count)
        {
            currentIndex = 0;
        }

        PopulateCard();
    }

    public void FlipCard()
    {
        animator.SetTrigger("startFlip");

    }

    public void EditCard()
    {
        editCardPanel.SetActive(true);
        flashCardPanel.SetActive(false);
        editCardPanel.GetComponentInChildren<AddCard>().previousPanel = flashCardPanel;
        editCardPanel.GetComponentInChildren<AddCard>().newCard = false;

        foreach (KeyValuePair<int, FlashCard> kvp in cardDict)
        {
            if (kvp.Value == cardSet[currentIndex])
            {
                editCardPanel.GetComponentInChildren<AddCard>().cardIndex = kvp.Key;
            }
        }

        editCardPanel.GetComponentInChildren<AddCard>().cardFrontInput.text = cardSet[currentIndex].cardFrontText;
        editCardPanel.GetComponentInChildren<AddCard>().cardBackInput.text = cardSet[currentIndex].cardBackText;


    }
}
