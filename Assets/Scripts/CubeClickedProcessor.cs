
using UnityEngine;

public class CubeClickedProcessor : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private CubeFactory _cubeFactory;

    private void OnEnable()
    {
        _userInput.OnCubeClicked += CubeClick;
    }

    private void OnDisable()
    {
        _userInput.OnCubeClicked -= CubeClick;
    }

    private void CubeClick(Cube cube)
    {
        _cubeFactory.CreateCubes(cube);
    }
}
