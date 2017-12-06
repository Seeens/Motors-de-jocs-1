using UnityEngine;

public class Player_State : MonoBehaviour
{

    [SerializeField] private UI_HurtEffect _hurtEffect;
    [SerializeField] private UI_DebugInfo _debugInfo;

    private float _health = 1000.0f;
    private int _damageReduction = 0;

    private GameObject[] _spellTable = new GameObject[4];

    private GameObject _mainCamera;

    void Start()
    {
        _mainCamera = GameObject.FindWithTag("LobbyCamera");
        _mainCamera.SetActive(false);

        _hurtEffect = GameObject.FindWithTag("UI").GetComponentInChildren<UI_HurtEffect>();
        _debugInfo = GameObject.FindWithTag("UI").GetComponent<UI_DebugInfo>();
    }

    void Update()
    {
    }

    /* Yields damage and flickers screen*/
    public void YieldDamage(float damage)
    {
        _health = _health - (damage * (1 - _damageReduction));
        _debugInfo.UpdateHealth(_health);
        _hurtEffect.StartEffect();
    }

    public float GetHealth()
    {
        return _health;
    }

}
