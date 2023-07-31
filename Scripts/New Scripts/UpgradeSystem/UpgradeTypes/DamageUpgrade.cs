public class DamageUpgrade : Upgrade, IUpgradeable
{
    public void Upgrade()
    {
        LevelUp();
        // Hasar artışı işlemleri
        // Örnek: playerDamage += 5; 
    }
}
