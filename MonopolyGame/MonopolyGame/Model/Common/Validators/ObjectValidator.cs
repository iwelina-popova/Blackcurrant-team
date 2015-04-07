namespace MonopolyGame.Model.Common.Validators
{
    using System;
    
    

    public static class ObjectValidator
    {
        public static void NullObjectValidation(object instance, string message = null)
        {
            if (instance == null)
            {
                throw new NullReferenceException(message);
            }
        }

        public static void StringNullOrEmptyValidator(string value, string message = null)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(message);
            }
        }

    }
}
