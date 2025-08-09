using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSceneMain : TestMain
{
    [SerializeField] private string _database;

    private TestController _testController;

    protected override void Awake()
    {
        _testController = new();

        base.Awake();

        _testController.onAction += OutputDebugLog;
        SceneManager.sceneLoaded += LoadDatabase;
    }

    protected override void OnDestroy()
    {
        _testController.Dispose();

        base.OnDestroy();

        _testController.onAction -= OutputDebugLog;
        SceneManager.sceneLoaded -= LoadDatabase;
    }

    private void OutputDebugLog(string text) =>
        Debug.Log(text);

    private void LoadDatabase(Scene arg0, LoadSceneMode arg1)
    {
        _testController.LoadData(_database);
    }    
}
