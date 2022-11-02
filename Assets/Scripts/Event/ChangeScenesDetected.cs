using System;

namespace Event
{
    public class ChangeScenesDetected
    {
        public Action action;

        public ChangeScenesDetected(Action _action)
        {
            action = _action;
        }
    }
}