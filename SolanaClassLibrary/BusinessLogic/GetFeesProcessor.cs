using Newtonsoft.Json.Linq;
using SolanaClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolanaClassLibrary.DataAccess;

namespace SolanaClassLibrary.BusinessLogic
{
    public class GetFeesProcessor
    {
        private GetFeesModel.Rootobject gfmr = new GetFeesModel.Rootobject();

        public GetFeesModel.Rootobject GetFeesModelRoot()
        {
            DA_GetFees dagf = new DA_GetFees();
            JObject job = JObject.Parse(dagf.GetJsonGetFees());

            gfmr.result = new GetFeesModel.Result();
            gfmr.result.context = new GetFeesModel.Context();
            gfmr.result.value = new GetFeesModel.Value();
            gfmr.result.value.feeCalculator = new GetFeesModel.Feecalculator();

            gfmr.jsonrpc = job["jsonrpc"].ToString();
            gfmr.result.context.slot = Convert.ToInt64(job["result"]["context"]["slot"]);
            gfmr.result.value.blockhash = job["result"]["value"]["blockhash"].ToString();
            gfmr.result.value.feeCalculator.lamportsPerSignature = Convert.ToInt32(job["result"]["value"]["feeCalculator"]["lamportsPerSignature"]);
            gfmr.result.value.lastValidSlot = Convert.ToInt64(job["result"]["value"]["lastValidSlot"]);
            gfmr.id = Convert.ToInt32(job["id"]);

            return gfmr;
        }
    }
}
