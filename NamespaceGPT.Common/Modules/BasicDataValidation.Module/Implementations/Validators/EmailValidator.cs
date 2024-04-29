using System.Text.RegularExpressions;
using NamespaceGPT.Common.Modules.BasicDataValidation.Module.Interfaces;

namespace NamespaceGPT.Common.BasicDataValidation.Module.Implementations.Validators
{
    public class EmailValidator : IValidator
    {
        public bool Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
