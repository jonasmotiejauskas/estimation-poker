using EstimationPoker.ApiService.Models.Dto;
using System.Text.RegularExpressions;

namespace EstimationPoker.ApiService.Services
{
    public interface IUserValidator
    {
        ValidationResult ValidateCreateUserDto(CreateUserDto createUserDto);
        ValidationResult ValidateName(string name);
        ValidationResult ValidateEmail(string email);
    }

    public class UserValidator : IUserValidator
    {
        public ValidationResult ValidateCreateUserDto(CreateUserDto createUserDto)
        {
            var validationResult = new ValidationResult();

            validationResult.Merge(ValidatePassword(createUserDto.Password));
            validationResult.Merge(ValidateName(createUserDto.Name));
            validationResult.Merge(ValidateEmail(createUserDto.Email));

            return validationResult;
        }
        public ValidationResult ValidatePassword(string password)
        {
            var validationResult = new ValidationResult();
            const int passwordLength = 500;
            if (!ValidateStringValue(password, passwordLength))
            {
                validationResult.Errors.Add($"Passworrd cannot be null, empty or longer than {passwordLength}");
            }
            string pattern = @"^(?=.*\d)(?=.*[A-Z])(?=.*[!@#$%^&*(),.?""':{}|<>]).{6,}$";
            if (!Regex.IsMatch(password, pattern))
            {
                validationResult.Errors.Add($"Password must have a number, uppercase letter, special character (e.g., !@#$%^&*()) and have at least 6 characters long");
            }
            return validationResult;
        }
        public ValidationResult ValidateName(string name)
        {
            var validationResult = new ValidationResult();
            const int nameLength = 150;
            if (!ValidateStringValue(name, nameLength))
            {
                validationResult.Errors.Add($"Name cannot be null, empty or longer than {nameLength}");
            }
            return validationResult;
        }


        public ValidationResult ValidateEmail(string email)
        {
            var validationResult = new ValidationResult();
            const int emailLength = 100;
            if (!ValidateStringValue(email, emailLength))
            {
                validationResult.Errors.Add($"Email cannot be null, empty or longer than {emailLength}");
            }

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email, pattern))
            {
                validationResult.Errors.Add($"Email format is incorrect");
            }
            return validationResult;
        }



        private static bool ValidateStringValue(string value, int stringLength)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > stringLength)
            {
                return false;
            }
            return true;
        }
    }

    public class ValidationResult
    {
        public bool IsValid => Errors.Count == 0;
        public List<string> Errors { get; set; } = new List<string>();

        public void Merge(ValidationResult other)
        {
            Errors.AddRange(other.Errors);
        }
    }
}

