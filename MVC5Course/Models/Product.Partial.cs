namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //if (this.Price < 50)
            //{
            //    yield return new ValidationResult("金額太小", new string[] { "Price" });
            //}

            //if (this.Stock > 10)
            //{
            //    yield return new ValidationResult("庫存量過少", new string[] { "Stock" });
            //}

            yield break;
        }
    }

    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        //[TwoSpaceAtLeast(ErrorMessage ="至少需有兩個空白字元以上")]
        [Required]
        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
