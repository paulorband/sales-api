﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
	public class ProductModel : ModelBase
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
	}
}