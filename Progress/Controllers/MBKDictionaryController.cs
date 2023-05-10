using Microsoft.AspNetCore.Mvc;
using Progress.Interfaces;
using Progress.Models;

namespace Progress.Controllers
{
    [Route("mbk/10")]
    public class MBKDictionaryController : Controller
    {
        private readonly IMBKDictionary _dictionary;

        public MBKDictionaryController(IMBKDictionary dictionary)
        {
            _dictionary = dictionary;
        }


        [Route("search")]
        public async Task<IEnumerable<Diagnosis>> GetDiagnoses([FromQuery] string search)
        {
            return _dictionary.GetDiagnoses(search);
        }
    }
}