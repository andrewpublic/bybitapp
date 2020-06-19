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
            display.Text = await client.GetStringAsync("https://api-testnet.bybit.com/v2/public/tickers");
        }

        private void lblMain_Click(object sender, EventArgs e)
        {

        }
    }
}
