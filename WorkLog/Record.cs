using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLog
{
    public class Record
    {
        public string Client { get; set; }
        public string ProService { get; set; }
        public string Task { get; set; }
        public string Item { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double TotalHours { get; set; }
        public double ReimburseAmount { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public string FullRecord => $"{Client}" + "|" + $"{ProService}" + "|" + $"{Task}" + "|" + $"{Item}" + "|" + $"{Date}" + "|" + $"{StartTime}" + "|" + $"{EndTime}" + "|" + $"{TotalHours}";
    }
}
