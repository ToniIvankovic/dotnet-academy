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
            Key = "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";
            From = "student@academy.byinfinum.co";
        }
    }
}
