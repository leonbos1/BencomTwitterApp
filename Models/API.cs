namespace BencomTwitterApp.Models
{
    public class API
    {
        private string _BearerToken;


        public API()
        {
            _BearerToken = "AAAAAAAAAAAAAAAAAAAAAEswiAEAAAAAN5n12SejPIh8osChcGjzXK%2BXiqw%3DBrgpvcLXgQ6iROiZ139Cq4QVRLjDTZXlq6f9NKlPBhjF3HjBOj";
        }

        public string getBearerToken()
        {
            return _BearerToken;
        }
    }
}
