namespace CoreGame.Utils.Interface
{
    public interface IAliveObject
    {
        IHealthSystem HealthSystem  {get;}
        void Death();
    }
}