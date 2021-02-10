using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolanaClassLibrary.Models
{
    public class GetFeesModel
    {

        public class Rootobject
        {
            public string jsonrpc { get; set; }
            public Result result { get; set; }
            public int id { get; set; }
        }

        public class Result
        {
            public Context context { get; set; }
            public Value value { get; set; }
        }

        public class Context
        {
            public long slot { get; set; }
        }

        public class Value
        {
            public string blockhash { get; set; }
            public Feecalculator feeCalculator { get; set; }
            public long lastValidSlot { get; set; }
        }

        public class Feecalculator
        {
            public int lamportsPerSignature { get; set; }
        }

    }
}
