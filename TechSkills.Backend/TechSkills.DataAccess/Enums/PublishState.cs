using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSkills.DataAccess.Enums
{
	public enum PublishState
	{
		[Description("Создание")] // Автор курса еще не завершил содание курса или работает над исправлением ошибок, выявленых при модерации
		Draft = 1,

		[Description("Модерация")] // Автор курса отправил на проверку созданный им курс
		Review = 2,

		[Description("Опубликован")] //Курс прошел модерацию и попал в общий доступ
		Published = 3
	}
}
