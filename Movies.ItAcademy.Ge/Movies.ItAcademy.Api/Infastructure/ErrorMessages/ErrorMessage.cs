namespace Movies.ItAcademy.Api.Infastructure.ErrorMessages
{
    public static class ErrorMessage
    {
        public const string FirstName = "First Name Cannot be Empty";
        public const string LastName = "Last Name Cannot be Empty";
        public const string UserName = "User Name Cannot be Empty";
        public const string Email = "Email is required";
        public const string ConfirmPassword = "ConfirmPassword must be equal password";
        public const string PasswordLength = "Password Length must be minimum 8 character";
        public const string PasswordUppercaseLetter = "In the password  must be minimum 1 Uppercase character";
        public const string PasswordLovercaseLetter = "In the password  must be minimum 1 Lowercase character";
        public const string PasswordDigit = "In the password must be digit";
    }
}
