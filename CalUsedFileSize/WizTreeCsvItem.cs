using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsvHelper.Configuration.Attributes;

namespace WizTreeTools
{
	public class WizTreeCsvItem
	{
		//[Name("文件名称")]
		[Index(0)]
		public string Path { get; set; }

		//[Name("大小")]
		[Index(1)]
		public long Size { get; set; }

		//[Name("分配")]
		[Index(2)]
		public long AllocationSize { get; set; }

		//[Name("修改时间")]
		[Index(3)]
		public DateTime ModfiyTime { get; set; }

		//[Name("属性")]
		[Index(4)]
		public int Attribute { get; set; }

		//[Name("文件")]
		[Index(5)]
		public int FloderAmount { get; set; }

		//[Name("文件夹")]
		[Index(6)]
		public int FileAmount { get; set; }
	}
}
