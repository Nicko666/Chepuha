using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public abstract class Window : MonoBehaviour
{
    private Animator _animator;

    private InputManager _inputManager;
    protected GameManager _gameManager;
    protected WindowsManager _windowsManager;
    protected GameEventManager _gameEventManager;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();

        _inputManager = InputManager.Instance;
        _gameManager = GameManager.Instance;
        _windowsManager = WindowsManager.Instance;
        _gameEventManager = GameEventManager.Instance;

    }

    protected virtual void OnEnable()
    {
        _inputManager.OnEscape += OnEscape;
        _inputManager.OnEscapeHold += OnEscapeHold;

    }

    protected virtual void OnDisable()
    {
        _inputManager.OnEscape -= OnEscape;
        _inputManager.OnEscapeHold -= OnEscapeHold;

    }

    abstract public void OnEscape();

    abstract public void OnEscapeHold();

    public void Open()
    {
        //if (_animator == null)
        //{
        //    _animator = GetComponent<Animator>();
        //}

        //gameObject.SetActive(true);

        //_animator.SetBool("Open", true);

        gameObject.SetActive(true);

    }

    public void Close()
    {
        //if (_animator == null)
        //{
        //    _animator = GetComponent<Animator>();
        //}

        //_animator.SetBool("Open", false);

        gameObject.SetActive(false);

    }


}
