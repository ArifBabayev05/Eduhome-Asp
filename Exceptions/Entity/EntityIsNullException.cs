using System;
namespace Exceptions.Entity
{
    public class EntityIsNullException : Exception
    {
        private static string _message = "Data could not find!";
        public EntityIsNullException() : base(_message)
        {
             
        }
    }
}

