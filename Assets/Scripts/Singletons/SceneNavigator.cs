using UnityEngine.SceneManagement;

public class SceneNavigator : Singleton<SceneNavigator>
{
    public void GoToExplorationMap() => GoToScene("Exploration");

    public void GoToBattleEvent() => GoToScene("Battle");

    public void GoToAsteroidsEvent() => GoToScene("Asteroids");

    private void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
