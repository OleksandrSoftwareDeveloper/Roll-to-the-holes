using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextWithScore : MonoBehaviour
{
    [SerializeField] private Score m_Score;
    [SerializeField] private string m_TextBeforeScore;
    [SerializeField] private string m_TextAfterScore;
    [SerializeField] private bool m_ShouldRewriteInFixedUpdate;

    private Text m_ThisText;

    private void Awake()
    {
        m_ThisText = GetComponent<Text>();
    }

    private void RewriteTextWithScore()
    {
        m_ThisText.text = $"{m_TextBeforeScore}{m_Score.CurrentScore}{m_TextAfterScore}";
    }

    private void OnEnable()
    {
        RewriteTextWithScore();
    }

    private void FixedUpdate()
    {
        if(m_ShouldRewriteInFixedUpdate)
        {
            RewriteTextWithScore();
        }
    }
}