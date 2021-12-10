using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
public class Author
{
	public Author()
	{
		Posts = new HashSet<Post>();
	}
	public int Id { get; set; }
	public string Nick { get; set; }
	public DateTime JoinDate { get; set; }
	public ICollection<Post> Posts { get; set; }
}

