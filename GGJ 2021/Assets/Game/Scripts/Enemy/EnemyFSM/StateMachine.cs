public class StateMachine
{
    private IState _currentState;

    public void ChangeState(IState newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = newState;
        _currentState.Enter();

    }

    public void Update(bool isPlayerVisible, bool isFound, EnemyController owner)
    {
        if (_currentState != null)
        {
            _currentState.Execute();
            if (_currentState is EnemyChaseState && !isPlayerVisible && !isFound)
            {
                this.ChangeState(new EnemyPatrolState(owner));
            }
        }
    }
}
