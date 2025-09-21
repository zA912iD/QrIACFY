// 代码生成时间: 2025-09-22 05:33:24
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;

namespace ValidationExample
{
    // Define a custom ValidationException to handle validation errors
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationResult> Results { get; private set; }

        public ValidationException(IEnumerable<ValidationResult> results) : base("Validation failed.")
        {
            Results = results;
        }
    }

    public class FormValidator
    {
        // Validate the form data using the provided object
        public IEnumerable<ValidationResult> Validate(object formData)
        {
            // Create a validation context for the object
            var context = new ValidationContext(formData, serviceProvider: null, items: null)
            {
                DisplayName = "Form Data"
            };
            // Collect the results of the validation
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(formData, context, results, true))
            {
                // If validation fails, throw a custom exception with the results
                throw new ValidationException(results);
            }
            return results;
        }
    }

    // Example of a ViewModel with validation attributes
    public class FormData
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
    }
}
