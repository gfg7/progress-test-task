using System.ComponentModel.DataAnnotations;
namespace Progress.Utils
{
    public enum SearchFilterEnum : int
    {
        [Display(Name ="Все")]
        All = 0,
        [Display(Name ="ФИО")]
        FullName = 1,
        [Display(Name ="Телефон")]
        Phone = 2,
        [Display(Name ="Дата рождения")]
        BirthDate = 3
    }
}