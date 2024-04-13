using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Column]
        public string name { get; set; }
        [Column]
        public string email { get; set; }
        [Column]
        public string address { get; set; }
        [Column]
        public int phonenumber { get; set; }
    }       
    public class Drug
    {
        [Key]
        public int Id { get; set; }
        
        public string drugname { get; set; } = null!;
        
        public string genericnames { get; set; } = null!;
        
        public string dosetype { get; set; } = null!;
        
        public string company { get; set; } = null!;
    }
    public class Donation
    {
        [Key]
        public int Id { get; set; }
        public User Doner { get; set; } = null!;
        public string Recipient { get; set; } = null!;

        public DateTime Date { get; set; }
    }
    public class MoneyDonation : Donation
    {
        public int MoneyAmount { get; set; }
    }
    public class DrugDonation : Donation
    {
        public Drug Drug { get; set; } = null!;
        public String Quantity { get; set; } = null!;
    }
    public class Request
    {
        [Key]
        public int Id { get; set; }
        
        public User AskedUser { get; set; } = null!;
        
        public User Doner { get; set; } = null!;
        
        public DateTime Date { get; set; }
    }
    public class MoneyRequest : Request
    {
        public int MoneyAmount { get; set; }
    }
    public class DrugRequest : Request
    {
        public Drug Drug { get; set; } = null!;
        public String Quantity { get; set; } = null!;
    }}
