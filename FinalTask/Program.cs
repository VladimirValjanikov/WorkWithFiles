using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
	[Serializable]
	public class Student
	{
		public string Name { get; set; }
		public string Group { get; set; }
		public DateTime DateOfBirth { get; set; }

		public Student(string name, string group, DateTime dt)
		{
			Name = name;
			Group = group;
			DateOfBirth = dt;
		}
	}
	internal class Program
	{				
		static void Main(string[] args)
		{
			string filePath = Console.ReadLine();

			string desktopPath = @"C:\Users\User\Desktop";		

			BinaryFormatter formatter = new BinaryFormatter();

			Student[] students;

			using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
			{
				students = (Student[])formatter.Deserialize(fs);
			}
			
			var groups = new string[students.Length];

			for (int i = 0; i < students.Length; i++)			
				groups[i] = students[i].Group;
			
			var uniqGroups = groups.Distinct().ToArray();
			var path = Directory.CreateDirectory(desktopPath + "\\Students").ToString();			
						
			foreach (var group in uniqGroups)
			{
				using (StreamWriter sw = File.CreateText($@"{path}\{group}.txt"))
				{
					foreach (var student in students)
					{
						if (student.Group == group)											
							sw.WriteLine($"{student.Name}, {student.DateOfBirth}");													
					}
				}
			}			
		}		
	}
}