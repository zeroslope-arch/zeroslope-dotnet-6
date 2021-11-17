using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ZeroSlope.Domain.Entities
{
	[Table("SampleEntity")]
	public class SampleEntity
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public string Description { get; set; }
	}
}
