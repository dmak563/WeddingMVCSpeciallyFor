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
        [Required, Display(Name = "ФИО")]
        public string Fio { get; set; }
        [Display(Name = "Сможете ли вы присутсвовать на нашей свадьбе?")]
        public bool IsExist { get; set; }
        [MaxLength(20)]
        [Required, Display(Name = "Любимый цвет")]
        public string FavouriteColor { get; set; }
        [MaxLength(30)]
        [Required, Display(Name = "Любимая песня или исполнитель молодости(детства)")]
        public string FavouriteSong { get; set; }
        [MaxLength(5), Display(Name = "Группа крови")]
        public string Blood { get; set; }
        [Display(Name = "Попкорн ням-ням ?")]
        public bool PopcornIsCool { get; set; }
        [Required]
        [Display(Name = "Размер обуви")]
        public int FootSize { get; set; }
        [MaxLength(250)]

        [Required, DataType(DataType.MultilineText), Display(Name = "Почему кактус колючий ?")]
        public string WhyIsCactusPrickly { get; set; }
        [MaxLength(50), Display(Name = "Желтый или зеленый ?")]
        public string YellowOrGreen { get; set; }
        [MaxLength(50)]
        [Required, Display(Name = "Столица Бразилии")]
        public string CapitalOfBrazil { get; set; }
        [MaxLength(5000)]
        [Required]
        [DataType(DataType.MultilineText), Display(Name = "Несколько слов о нас")]
        public string AboutUs { get; set; }
        [MaxLength(5000)]
        [Required]
        [DataType(DataType.MultilineText), Display(Name = "Смешной случай или воспоминания связанные с женихом/невестой")]
        public string Joke { get; set; }
    }
}