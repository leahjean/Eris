namespace Assets.Scripts.Events
{
    public abstract class GameEvent
    {
        public string GetName() {
            return this.GetType().Name;
        }
    }
}