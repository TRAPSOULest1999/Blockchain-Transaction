using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationAndLogin
{

    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void btnSubmitReq_Click(object sender, EventArgs e)
        {
            // Get transaction details from user
            var transaction = new Transaction
            {
                Id = 1,
                FromAddress = textBoxFromAddr.Text,
                ToAddress = textBoxToAddr.Text,
                Amount = decimal.Parse(textBoxAmt.Text),
                Timestamp = DateTime.UtcNow,
                Hash = "transaction_hash"
            };

            // Simulate blockchain API response
            var response = new Dictionary<string, object>
        {
            { "hash", transaction.Hash },
            { "block_height", 12345 },
            { "block_time", DateTime.UtcNow },
            { "inputs", new List<Dictionary<string, object>> {
                    new Dictionary<string, object> {
                        { "address", transaction.FromAddress },
                        { "value", transaction.Amount },
                    }
                }
            },
            { "outputs", new List<Dictionary<string, object>> {
                    new Dictionary<string, object> {
                        { "address", transaction.ToAddress },
                        { "value", transaction.Amount },
                    }
                }
            }
        };

            //lbl1Response.Text = "API response: " + response.ToString();
            //lblResponse.Text = $"{transaction.Amount} sent to {transaction.ToAddress} at {transaction.block_time.ToString("yyyy-MM-dd HH:mm:ss")}";
            // Extract transaction details from the response dictionary
            decimal amount = (decimal)((List<Dictionary<string, object>>)response["outputs"])[0]["value"];
            string toAddress = (string)((List<Dictionary<string, object>>)response["outputs"])[0]["address"];
            DateTime blockTime = (DateTime)response["block_time"];

            // Format the response message
            string responseMsg = string.Format("{0} sent to {1} at {2}", amount, toAddress, blockTime);

            // Update the label with the response message
            lbl1Response.Text = "API response: " + responseMsg;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Close the current window
            this.Close();

            // Navigate to the login window
            var loginWindow = new Login();
            loginWindow.Show();
        }
    }
    class Transaction
    {
        public int Id { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public string Hash { get; set; }
    }
}
