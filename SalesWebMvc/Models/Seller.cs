﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
	public class Seller
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public DateTime BirthDate { get; set; }
		public decimal BaseSalary { get; set; }
		public Department Department { get; set; }
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
