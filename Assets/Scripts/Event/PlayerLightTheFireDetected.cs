namespace Event
{
    public class PlayerLightTheFireDetected
    {
        public Lamp lamp;

        public bool isLight;

        public PlayerLightTheFireDetected(Lamp _lamp , bool _isLight)
        {
            lamp = _lamp;
            isLight = _isLight;
        }
    }
}