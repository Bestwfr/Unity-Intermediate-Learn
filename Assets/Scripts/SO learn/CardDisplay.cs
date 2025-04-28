using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private SO_Card _cardProfile;
    
    [Header("Character Details")]
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _type;
    
    [Header("Character Attributes")]
    [SerializeField] private TMP_Text _costText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _attackText;

    [Space]
    [SerializeField] private Image _characterImage;
    [SerializeField] private float xOffset,yOffset;

    [Button]
    public void SetupCard()
    {
        _name.text = _cardProfile.Name;
        _description.text = _cardProfile.Description;
        _type.text = _cardProfile.ElementalType.ToString();
        
        _costText.text = _cardProfile.Cost.ToString();
        _healthText.text = _cardProfile.Health.ToString();
        _attackText.text = _cardProfile.ATK.ToString();
        
        _characterImage.sprite = _cardProfile.CharacterImage;
        _characterImage.rectTransform.anchoredPosition = new Vector2(xOffset, yOffset);
    }
}
