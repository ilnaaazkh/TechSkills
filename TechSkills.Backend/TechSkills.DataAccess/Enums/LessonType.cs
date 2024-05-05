using System.ComponentModel;

namespace TechSkills.DataAccess.Enums
{
	public enum LessonType
	{
		[Description("Теоретический урок")]
		Theory = 1,

		[Description("Практический урок")]
		Practice = 2,

		[Description("Тест")]
		Test = 3
	}
}
