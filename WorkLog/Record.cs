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
        public int ReimburseAmount { get; set; }
        //public double TotalCost { get; set; }
        //public int Rate { get; set; }
        public string Description { get; set; }

        public string FullRecord
        {
            get
            {
                return $"{Client} {ProService} {Task} {Item} {Date} {StartTime} {EndTime} {TotalHours}";
            }
        }

        public string PrintRecord()
        {
            string ret = "";

            ret += Client + " : " + ProService + " : " + Task + " : " + Item + " : " + 
                String.Format("{0:M/d/yyyy}", Date) + " : " + String.Format("{0:t}", StartTime) + " : " + String.Format("{0:t}", EndTime);

            return ret;
        }



    }




}
