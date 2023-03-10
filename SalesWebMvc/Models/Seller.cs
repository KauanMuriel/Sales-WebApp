using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
	public class Seller
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "{0} required")]
		[StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1} characters")]
		public string Name { get; set; }

		[Required(ErrorMessage = "{0} required")]
		[EmailAddress(ErrorMessage = "Enter a valid {0}")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "{0} required")]
		[Display(Name = "Birth Date")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd:MM:yyyy}")]
		public DateTime BirthDate { get; set; }

		[Required(ErrorMessage = "{0} required")]
		[Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
		[Display(Name = "Base Salary")]
		[DisplayFormat(DataFormatString = "{0:F2}")]
		public decimal BaseSalary { get; set; }

		public Department Department { get; set; }
		public int DepartmentId { get; set; }
		public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

		public Seller()
		{
		}

		public Seller(int id, string name, string email, DateTime birthDate, decimal baseSalary, Department department)
		{
			Id = id;
			Name = name;
			Email = email;
			BirthDate = birthDate;
			BaseSalary = baseSalary;
			Department = department;
		}

		public void AddSales(SalesRecord sale)
		{
			Sales.Add(sale);
		}

		public void RemoveSales(SalesRecord sale)
		{
			Sales.Remove(sale);
		}

		public double TotalSales(DateTime initialDate, DateTime finalDate)
		{
			return Sales.Where(x => x.Date <= initialDate && x.Date >= finalDate).Sum(x => x.Amount);
		}
	}

}

