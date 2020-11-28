﻿using System;

namespace Sales.Domain
{
	public class EntityValidationException : Exception
	{
		public EntityValidationException(string message) : base(message)
		{
		}
	}
}
