namespace CoreGame.Utils.Interface
{
    public interface IDamagable
    {
        void ReceiveHit(int damage);
        int GetHp();
    }
}