using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IAutrhorRepository
{
	IQueryable<Author> Authors { get; }
}
