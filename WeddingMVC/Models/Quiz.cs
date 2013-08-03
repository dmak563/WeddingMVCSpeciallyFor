using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WeddingMVC.Models
{
    public class Quiz
    {
        public Quiz()
        {
            IsExist = true;
            PopcornIsCool = true;
            FootSize = 41;
        }

        [MaxLength(50)]
        [DisplayName("Ваше ФИО")]
        public string Fio { get; set; }

        [DisplayName("Сможете ли вы прийти на нашу свадьбу?")]
        public bool IsExist { get; set; }

        [MaxLength(20)]
        [DisplayName("Ваш любимый цвет")]
        public string FavouriteColor { get; set; }

        [MaxLength(30)]
        [DisplayName("Любимая песня или исполнитель вашей молодости(детства)")]
        public string FavouriteSong { get; set; }

        [MaxLength(5)]
        [DisplayName("Ваша группа крови")]
        public string Blood { get; set; }

        [DisplayName("Любите ли вы попкорн?")]
        public bool PopcornIsCool { get; set; }

        [DisplayName("Ваш размер обуви")]
        public int FootSize { get; set; }

        [MaxLength(250)] 
        [DisplayName("Почему кактус колючий?")]
        public string WhyIsCactusPrickly { get; set; }

        [MaxLength(50)]
        [DisplayName("Желтый или зеленый?")]
        public string YellowOrGreen { get; set; }
        
        [MaxLength(50)]
        [DisplayName("Столица Бразилии?")]
        public string CapitalOfBrazil { get; set; }
        
        [MaxLength(5000)]
        [DisplayName("Несколько слов о нас")]
        public string AboutUs { get; set; }

        [MaxLength(5000)]
        [DisplayName("Смешной случай или воспоминания связанные с женихом/невестой")]
        public string Joke { get; set; }
    }
}