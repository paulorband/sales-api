using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
	public class SaleStatusModel
	{
		public long SaleId { get; set; }
		public SaleStatus Status { get; set; }
	}
}
