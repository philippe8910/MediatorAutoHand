namespace Interface
{
    public interface ITrigger
    {
        public void OnTriggerEnter();

        public void OnTriggerStayTrue();
        
        public void OnTriggerStayFalse();

        public void OnTriggerExit();
    }
}