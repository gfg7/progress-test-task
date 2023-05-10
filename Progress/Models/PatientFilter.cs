using System.Linq.Expressions;
using Progress.Interfaces;
using Progress.Utils;

namespace Progress.Models
{
    public class PatientFilter : IFilter<Patient>
    {
        public string? SearchString { get; set; }
        public SearchFilterEnum SearchParam { get; set; }
        public Expression<Func<Patient, bool>> GetFilter()
        {
            Expression<Func<Patient, bool>> filter = null;

            if (string.IsNullOrEmpty(SearchString?.Trim()))
            {
                return filter = x => true;
            }

            if (SearchParam == SearchFilterEnum.All)
            {
                filter = x =>
                (
                    SearchParam == SearchFilterEnum.All &&
                    (
                        x.Surname.ToLower().Contains(SearchString.ToLower()) ||
                        x.Name.ToLower().Contains(SearchString.ToLower()) ||
                        (x.Patronymic + "").ToLower().Contains(SearchString.ToLower()) ||
                        x.PhoneNumber.Contains(SearchString) ||
                        x.DateOfBirth.ToString().Contains(SearchString)
                    )
                );
            }
            else
            {
                filter = x =>
                (SearchParam == SearchFilterEnum.FullName &&
                    (
                        x.Surname.ToLower().Contains(SearchString.ToLower()) ||
                        x.Name.ToLower().Contains(SearchString.ToLower()) ||
                        (x.Patronymic + "").ToLower().Contains(SearchString.ToLower())
                    )
                ) ||
                (SearchParam == SearchFilterEnum.Phone && x.PhoneNumber.Contains(SearchString)) ||
                (SearchParam == SearchFilterEnum.BirthDate && x.DateOfBirth.ToString().Contains(SearchString));
            }

            return filter;
        }
    }
}