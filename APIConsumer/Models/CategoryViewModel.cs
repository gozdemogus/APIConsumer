using System;
namespace WebApplication1.Models
{
	public class CategoryViewModel
	{
		public CategoryViewModel()
		{
		}
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public bool Status { get; set; }
	}
}

