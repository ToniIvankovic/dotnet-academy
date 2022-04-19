using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ToniIvankovic.Contracts.Dtos
{
    public class EmailSettings
    {
        public string Key { get; set; }
        public string From { get; set; }

        public EmailSettings()
        {
        }

        public EmailSettings(string k, string f)
        {
            Key = k;
            From = f;
        }
    }
}
