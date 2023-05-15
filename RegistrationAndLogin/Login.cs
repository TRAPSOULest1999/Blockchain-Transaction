using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Diagnostics;

namespace RegistrationAndLogin
{
    public partial class Login : Form
    {
        // Constants
        private static readonly BigInteger N = BigInteger.Parse("115792089237316195423570985008687907853269984665640564039457584007913129639747");
        private static readonly BigInteger G = BigInteger.ModPow(2, 128, N);

        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;
        // Specify the full path for the log file
        static string logFilePath = @"C:\Users\neole\OneDrive\Documents\University of Pretoria\BSc Computer Sciences Honours\2023\COS720\0 - Project\Concept\RegistrationAndLogin\login.log";
        // Create a TextWriterTraceListener object to represent the log file
        TextWriterTraceListener logListener = new TextWriterTraceListener(logFilePath);

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Add the logListener to the Trace object
            Trace.Listeners.Add(logListener);
            // Write events to the log file
            Trace.WriteLine($"{DateTime.Now} - Connected to database");
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\neole\OneDrive\Documents\University of Pretoria\BSc Computer Sciences Honours\2023\COS720\0 - Project\Concept\RegistrationAndLogin\Database.mdf;Integrated Security=True");
            cn.Open();
            // Write events to the log file
            Trace.WriteLine($"{DateTime.Now} - Connected to database");


        }

        private void btn2Register_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.ShowDialog();

        }
        private bool IsValidEmail(string email)
        {
            // Regular expression pattern for email validation
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Check if email matches the pattern
            return Regex.IsMatch(email, pattern);
        }

        // Generate a new private key
        public static BigInteger GeneratePrivateKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var privateKey = new byte[32];
                rng.GetBytes(privateKey);
                return new BigInteger(privateKey);
            }
        }

        // Generate the corresponding public key
        public static BigInteger GeneratePublicKey(BigInteger privateKey)
        {
            var generator = BigInteger.ModPow(2, 128, N); // Generator = 2^128 mod N
            var exponent = BigInteger.Abs(privateKey);
            return BigInteger.ModPow(generator, exponent, N);
        }

        // Generate a random nonce for the NIZKP
        public static BigInteger GenerateNonce()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var nonce = new byte[32];
                rng.GetBytes(nonce);
                return new BigInteger(nonce);
            }
        }

        // Compute the challenge value for the NIZKP
        public static BigInteger ComputeChallenge(BigInteger publicKey, BigInteger nonce)
        {
            var hash = SHA256.Create().ComputeHash(publicKey.ToByteArray().Concat(nonce.ToByteArray()).ToArray());
            return new BigInteger(hash);
        }

        // Compute the response value for the NIZKP
        public static BigInteger ComputeResponse(BigInteger privateKey, BigInteger challenge, BigInteger password)
        {
            return (privateKey + challenge * password) % N;
        }

        // Verify the NIZKP
        public static bool VerifyNIZKP(BigInteger publicKey, BigInteger nonce, BigInteger challenge, BigInteger response, BigInteger password)
        {
            var generator = BigInteger.ModPow(2, 128, N); // Generator = 2^128 mod N
            //var leftHandSide = BigInteger.ModPow(generator, response, N);
            var leftHandSide = BigInteger.ModPow(generator, BigInteger.Abs(response), N);
            //var rightHandSide = publicKey * BigInteger.ModPow(password, challenge, N) % N * BigInteger.ModPow(nonce, challenge, N) % N;
            var rightHandSide = (publicKey * BigInteger.ModPow(password, challenge, N) % N * BigInteger.ModPow(nonce, challenge, N)) % N;

            if (challenge < 0)
            {
                // Write events to the log file
                Trace.WriteLine($"{DateTime.Now} - The challenge parameter must be greater than or equal to zero.");
                throw new ArgumentException("The challenge parameter must be greater than or equal to zero.", nameof(challenge));
            }

            var computedHash = SHA256.Create().ComputeHash(publicKey.ToByteArray().Concat(nonce.ToByteArray()).ToArray());
            var computedChallenge = new BigInteger(computedHash);
            //What is happening here?
            return leftHandSide == rightHandSide || challenge == computedChallenge;
        }

        private void btn1Login_Click(object sender, EventArgs e)
        {
            // Get the input pin from a textbox
            string inputPin = txtBox1Pass.Text;

            // Check if the input is a numeric value
            if (!int.TryParse(inputPin, out int pin))
            {
                // Write events to the log file
                Trace.WriteLine($"{DateTime.Now} - Invlid Pin - Numeric");
                txtBox1Pass.Text = "";
                MessageBox.Show("Please enter a numeric pin.");
                return;
            }

            // Check if the pin is at least 6 digits long
            if (inputPin.Length < 6)
            {
                // Write events to the log file
                Trace.WriteLine($"{DateTime.Now} - Invalid Pin - Length");
                txtBox1Pass.Text = "";
                MessageBox.Show("Pin should be at least 6 digits long.");
                return;
            }

            // Check if the pin contains repeated or sequential digits
            bool isSequential = true;
            bool isRepeated = true;
            for (int i = 1; i < inputPin.Length; i++)
            {
                // Check for sequential digits
                if (inputPin[i] != inputPin[i - 1] + 1)
                {
                    isSequential = false;
                }

                // Check for repeated digits
                if (inputPin[i] != inputPin[i - 1])
                {
                    isRepeated = false;
                }
            }

            if (isSequential)
            {
                // Write events to the log file
                Trace.WriteLine($"{DateTime.Now} - Invalid Pin - Sequential");
                txtBox1Pass.Text = "";
                MessageBox.Show("Pin should not contain sequential digits.");
                return;
            }

            if (isRepeated)
            {
                // Write events to the log file
                Trace.WriteLine($"{DateTime.Now} - Invalid Pin Repeated");

                txtBox1Pass.Text = "";
                MessageBox.Show("Pin should not contain repeated digits.");
                return;
            }

            // If the pin passes all checks, it is valid
            MessageBox.Show("Pin is valid.");
            // Write events to the log file
            Trace.WriteLine($"{DateTime.Now} - Pin Valid");

            if (!IsValidEmail(txtBox1Email.Text))
            {
                // Write events to the log file
                Trace.WriteLine($"{DateTime.Now} - Invalid Email Address");
                txtBox1Email.Text = "";
                MessageBox.Show("Invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (txtBox1Pass.Text != string.Empty || txtBox1Email.Text != string.Empty)
                {
                    if (string.IsNullOrEmpty(txtBox1Pass.Text) || string.IsNullOrEmpty(txtBox1Email.Text))
                    {
                        // Write events to the log file
                        Trace.WriteLine($"{DateTime.Now} - Empty Password or Email");
                        MessageBox.Show("Please enter a value in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Parse password input as a BigInteger
                    if (!BigInteger.TryParse(txtBox1Pass.Text, out var password) || password < 0)
                    {
                        // Write events to the log file
                        Trace.WriteLine($"{DateTime.Now} - None Positive integer for password");
                        MessageBox.Show("Please enter a valid positive integer for the password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Generate a new private key and corresponding public key
                    var privateKey = GeneratePrivateKey();
                    var publicKey = GeneratePublicKey(privateKey);

                    // Get password from user
                    //Console.Write("Enter password: ");
                    //password = BigInteger.Parse(txtBox1Pass.Text);//Console.ReadLine());

                    // Generate a random nonce for the NIZKP
                    var nonce = GenerateNonce();

                    // Compute the challenge value for the NIZKP
                    var challenge = ComputeChallenge(publicKey, nonce);

                    // Compute the response value for the NIZKP
                    var response = ComputeResponse(privateKey, challenge, password);

                    // Verify the NIZKP
                    var isVerified = VerifyNIZKP(publicKey, nonce, challenge, response, password);

                    // Output result
                    MessageBox.Show(isVerified ? "Password authenticated successfully!" : "Password authentication failed.");

                    if (isVerified)
                    {
                        // Write events to the log file
                        Trace.WriteLine($"{DateTime.Now} - Successful Login of User: {txtBox1Email.Text}");
                        // Remove the logListener when finished
                        Trace.Listeners.Remove(logListener);
                        this.Hide();
                        Homepage home = new Homepage();
                        home.ShowDialog();
                    }

                    /*
                                    cmd = new SqlCommand("select * from LoginTable where Email='" + txtBox1Email.Text + "' and Password='" + txtBox1Pass.Text + "'", cn);
                                    dr = cmd.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        dr.Close();
                                        this.Hide();
                                        Homepage home = new Homepage();
                                        home.ShowDialog();
                                    }
                                    else
                                    {
                                        dr.Close();
                                        MessageBox.Show("No Account avilable with this email and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }*/

                }
                else
                {
                    MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
