namespace Task1
{
	internal class Program
	{
		// C:\Users\Варнавский\Desktop\SkillFactory		
		static void Main(string[] args)
		{			
			string path = Console.ReadLine();
			
			var di = new DirectoryInfo(path);
			//var s = FileSystemAclExtensions.GetAccessControl(di);
			try
			{
				//if (!di.Exists)
					//throw new Exception("Данного каталога не существует!");

				foreach (FileInfo file in di.GetFiles())
				{
					var timeSpan = DateTime.Now - file.LastAccessTime;

					if (timeSpan > TimeSpan.FromMinutes(30))
						Console.WriteLine("fail");
						//file.Delete();
				}
				foreach (DirectoryInfo dir in di.GetDirectories())
				{
					var timeSpan = DateTime.Now - dir.LastAccessTime;

					if (timeSpan > TimeSpan.FromMinutes(30))
						Console.WriteLine("papki");
						//dir.Delete(true);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}	
		}
	}
}