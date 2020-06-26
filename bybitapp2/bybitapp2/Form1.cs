using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace bybitapp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            function1();
        }

        private async void function1()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://api-testnet.bybit.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
              new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //Get
            ByBitRes deserializedProduct = JsonConvert.DeserializeObject<ByBitRes>(await client.GetStringAsync("https://api-testnet.bybit.com/v2/public/tickers"));
            DataTable workingSet = deserializedProduct.result;
            display.Text += workingSet.Rows[0].Field<string>("Symbol");
            display.Text += ": " + workingSet.Rows[0].Field<string>("last_price");
        }

        public class ByBitRes
        {
            public int ret_code { get; set; }
            public string ret_msg { get; set; }
            public string ext_code { get; set; }
            public string ext_info { get; set; }
            public DataTable result { get; set; }
            public DateTime time_now { get; set; }

        }
        private void lblMain_Click(object sender, EventArgs e)
        {

        }
    }
}
