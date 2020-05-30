using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace A045PriceQuotation.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum role
    {
        user,
        vendor,
        admin
    }

    public enum categ
    {
        user,
        vendor
    }

    public enum Availability
    {
        True,
        False
    }

    public enum Category
    {
        Gifts,
        Clothes,
        Footwear,
        Mobile,
        Laptop,
        Groceries,
        Electronics,
        PersonalCare,
        HomeAppliances,
        Bakery
    }


    public enum payment
    {
        CreditCard,
        DebitCard,
        PhonePe,
        GooglePay,
        Paytm
    }

    public class mainClass
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(25, MinimumLength = 4)]
        public string firstName { get; set; }

        
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(25, MinimumLength = 1)]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Gender gender { get; set; }


        [Required]
        [Display(Name = "Contact Number")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string contactNumber { get; set; }


        [Display(Name = "DOB")]                                               
        public DateTime? dob { get; set; }


        [Key]
        [Required]
        [Display(Name = "User Id")]
        [StringLength(20, MinimumLength = 6)]
        public string userId { get; set; }


        [Required]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$&])\S{6,20}$", 
            ErrorMessage = "Minimum length should be 6 containing alphabets, digits, special characters (All Included)")]
        [DataType(DataType.Password)]
        public string password { get; set; }


        [Required]
        [Display(Name = "Address")]
        [StringLength(50, MinimumLength = 10)]
        public string address { get; set; }

        [Required]
        [Display(Name = "Map Location")]
        [DataType(DataType.PostalCode)]
        public string mapLocation { get; set; }
        
             
        [Required]
        [Display(Name = "Status")]
        public string status { get; set; }


        //  [ForeignKey("user")]
        public categ categoryId { get; set; }                                   //done
                         
    }

    public class user
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int i { get; set; }
        public role role { get; set; }

    }

    public class product
    {
        [Key]
        public int productId { get; set; }

        [Required]
        [ForeignKey("foreignReal")]
        [Display(Name = "Id")]
        public string userId { get; set; }
        public virtual mainClass foreignReal { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Category")]
        public Category category { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Number of words should be in range 10-500 words")]
        public string description { get; set; }

        [Required(ErrorMessage = "Takes value as True or False")]
        [Display(Name = "Availability")]
        public bool availability { get; set; }

        [Required(ErrorMessage = "Enter any Integer")]
        [Display(Name = "Quantity")]
        public int quantity { get; set; }

        [Display(Name = "color")]
        public string color { get; set; }

    }

    public class pquotation
    {
        [Key]
        public int quotationId { get; set; }

        [ForeignKey("foreignProduct")]
        public int productId { get; set; }
        public product foreignProduct { get; set; }
        public string userId { get; set; }
        public string vendorId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool availability { get; set; }
        public Category category { get; set; }
        public string color { get; set; }
        public int? quantity { get; set; }
        public int? quotation { get; set; }
        public string status { get; set; }
        public string vendorStatus { get; set; }

    }

    public class bill
    {
        [Key]
        public int payId { get; set; }

        [ForeignKey("foreignQuotation")]
        public int quotationId { get; set; }
        public pquotation foreignQuotation { get; set; }

        public DateTime billDate { get; set; }

        public payment paymentMode { get; set; }
    }


   /* public class account
    {
        [Key]
        [Required]
        [RegularExpression(@"^[0-9]{16}$",
            ErrorMessage = "Account Number must of length 16.")]                           
        [Display(Name = "Account Number")]
        [StringLength(16)]
        public string accNumber { get; set; }
        [Required]
        public string name { get; set; }

        [Required] 
        public string address { get; set; }

        [Required] 
        public double balance { get; set; }

        public int debitcardNumber { get; set; }

        public int? creditcardNumber { get; set; }

        public string phoneNumber { get; set; }

        public int debitcvv { get; set; }

        public int creditcvv { get; set; }

        public int debitpin { get; set; }
        public int creditpin { get; set; }

    }*/

    public class account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int value { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{16}$",
            ErrorMessage = "account number must of length 16.")]                           
        [Display(Name = "account Number")]
        [StringLength(16)]
        public string accNumber { get; set; }

        [ForeignKey("foreignUserId")]
        public string userId { get; set; }
        public mainClass foreignUserId { get; set; }
        //public string userId { get; set; }

        

        [Required]
        public payment paymentMode { get; set; }
        [Required]
        public string name { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{16}$",
            ErrorMessage = "card number must of length 16.")]                           
        [Display(Name = "card Number")]
        [StringLength(16)]
        public string cardNumber { get; set; }
        [Required]
        public double amtPayable { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{3}$",
            ErrorMessage = "It must be of length 3.")]                          
        [Display(Name = "CVV")]
        [StringLength(3)]
        public string cvv { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{4}$",
             ErrorMessage = "pin must of length 4.")]                           
        [Display(Name = "pin")]
        [StringLength(4)]
        public string pin { get; set; }

    }

    public class categoryProduct
    {
        [Key]
        public int i { get; set; }
        public string category { get; set; }
    }

}