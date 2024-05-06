﻿using CafeBook.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeBook.DataAccess.Repository.IRepository
{
	public interface ICategoryRepository : IRepository<Category>
	{
		void Update(Category obj);
	}
}
