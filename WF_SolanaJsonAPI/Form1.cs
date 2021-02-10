using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SolanaClassLibrary.DataAccess;
using SolanaClassLibrary.BusinessLogic;
using SolanaClassLibrary.Models;

namespace WF_SolanaJsonAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            #region FillBigTextBox 
            // code in this region populates big text box with JSON result
            // first call to getFees REST method 
            DA_GetFees dagf = new DA_GetFees();
            // formats the string into "pretty" for eye format, like in Postman :)
            JToken jtoken = JsonConvert.DeserializeObject<JToken>(dagf.GetJsonGetFees());
            try
            {
                textBox1.Text = jtoken.ToString();
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message.ToString() + Environment.NewLine;
                textBox1.Text += ex.StackTrace.ToString() + Environment.NewLine;
                MessageBox.Show(ex.Message.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            #region FillTextBoxesFromObjects
            // code in this region populates text boxes from objects
            // second call to getFees REST method through GetFeesProcessor
            GetFeesModel.Rootobject gr = new GetFeesModel.Rootobject();
            GetFeesProcessor gp = new GetFeesProcessor();
            gr = gp.GetFeesModelRoot();

            textBox2.Text = gr.jsonrpc.ToString();
            textBox3.Text = gr.result.context.slot.ToString();
            textBox4.Text = gr.result.value.blockhash.ToString();
            textBox5.Text = gr.result.value.feeCalculator.lamportsPerSignature.ToString();
            textBox6.Text = gr.result.value.lastValidSlot.ToString();
            textBox7.Text = gr.id.ToString();
            #endregion
        }
    }
}
