

namespace Event
{
    public class OnEnableLevelHintDetected
    {
        public string hintSubtitleText;
        
        public OnEnableLevelHintDetected(string _hintSubtitleText)
        {
            hintSubtitleText = _hintSubtitleText;
        }
    }
}