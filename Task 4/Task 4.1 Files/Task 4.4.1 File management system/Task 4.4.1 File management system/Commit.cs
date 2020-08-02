using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._4._1_File_management_system
{
	public class Commit
	{
		private string _hash;
		private string _message;

		public Commit(string commitInLine)
		{
			string[] partsOfCommit = commitInLine.Split(' ');
			Hash = partsOfCommit[0];
			Message = partsOfCommit[1];
		}

		public string Hash
		{
			get
			{
				return _hash;
			}
			set
			{
				_hash = value;
			}
		}
		public string Message
		{
			get
			{
				return _message;
			}
			set
			{
				_message = value;
			}
		}
	}
}
