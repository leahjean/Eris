namespace Assets.Scripts.Player
{
    public class PlayerStatus
    {
        public float mHealth { get; set; }
        public float mMaxHealth { get; set; }
        public float mDefenseMultiplier { get; set; }
        public float mDefenseFlatValue { get; set; }


        public PlayerStatus(float maxHealth)
        {
            mMaxHealth = maxHealth;
            mHealth = maxHealth;
            mDefenseMultiplier = 1f;
            mDefenseFlatValue = 0f;
        }
    }
}