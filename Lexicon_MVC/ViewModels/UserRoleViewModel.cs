﻿namespace Lexicon_MVC.ViewModels
{
	public class UserRoleViewModel
	{
		public string UserId { get; set; }
		public string UserName { get; set; }
		public List<string> Roles { get; set; } = new List<string>();
	}
}
