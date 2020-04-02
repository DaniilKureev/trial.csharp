using SparkEquation.Trial.WebAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SparkEquation.Trial.WebAPI.Data.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CategoryProductsValidationAttribute : ValidationAttribute
    {
        public int MinElementsCount { get; set; }
        public int MaxElementsCount { get; set; }
        public string WrongCountErrorMessage => $"Collection has wrong elements count. Min:{this.MinElementsCount} Max:{this.MaxElementsCount}";
        public string NullCollectionErrorMessage => $"Collection is null";

        public CategoryProductsValidationAttribute(int minElementsCount, int maxElementsCount)
        {
            this.MinElementsCount = minElementsCount;
            this.MaxElementsCount = maxElementsCount;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult(this.NullCollectionErrorMessage);

            var collection = value as ICollection<CategoryProduct>;

            if(collection.Count < this.MinElementsCount || collection.Count > this.MaxElementsCount)
                return new ValidationResult(ErrorMessage ?? this.WrongCountErrorMessage);

            return ValidationResult.Success;
        }
    }
}
