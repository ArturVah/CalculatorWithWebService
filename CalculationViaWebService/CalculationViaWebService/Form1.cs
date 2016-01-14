using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace CalculationViaWebService
{
    public partial class Form1 : Form
    {
        private string function;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int x = Int32.Parse(txtX.Text);
            int y = Int32.Parse(txtY.Text);

            if (function == null)
            {
                MessageBox.Show("Pls enter one of the functions");
                return;
            }

            string param = "http://localhost:8080/calc/" + function;  
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(param);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"x\":\" " + x + " \"," +
                  "\"y\":\" " + y + "\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    txtResult.Text = result;
                    function = null;
                }
            }
            catch(WebException ex)
            {
                MessageBox.Show(((HttpWebResponse)ex.Response).StatusCode.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            function = "add";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            function = "sub";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            function = "divide";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            function = "concatenation";
        }

    }
}
