using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RegistrationAndLogin
{
    public partial class Registration : Form
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;

        public Registration()
        {
            InitializeComponent();
        }
        private bool IsValidEmail(string email)
        {
            // Regular expression pattern for email validation
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Check if email matches the pattern
            return Regex.IsMatch(email, pattern);
        }
        static byte[] GenerateEncryptionKey(string password, byte[] salt, int iterations, int keySize)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            return pbkdf2.GetBytes(keySize / 8);
        }

        static byte[] Encrypt(byte[] inputBytes, byte[] encryptionKey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = encryptionKey;
                aes.Mode = CipherMode.CBC;
                aes.GenerateIV();

                byte[] iv = aes.IV;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    memoryStream.Write(iv, 0, iv.Length);

                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                        cryptoStream.FlushFinalBlock();
                    }

                    byte[] encryptedBytes = memoryStream.ToArray();

                    return encryptedBytes;
                }
            }
        }

        static byte[] Decrypt(byte[] encryptedBytes, byte[] encryptionKey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = encryptionKey;
                aes.Mode = CipherMode.CBC;

                byte[] iv = new byte[aes.BlockSize / 8];
                Array.Copy(encryptedBytes, iv, iv.Length);
                aes.IV = iv;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(encryptedBytes, iv.Length, encryptedBytes.Length - iv.Length);
                        cryptoStream.FlushFinalBlock();
                    }

                    byte[] decryptedBytes = memoryStream.ToArray();

                    return decryptedBytes;
                }
            }
        }

        static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\neole\OneDrive\Documents\University of Pretoria\BSc Computer Sciences Honours\2023\COS720\0 - Project\Concept\RegistrationAndLogin\Database.mdf;Integrated Security=True");
            cn.Open();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Get the input pin from a textbox
            string inputPin = txtBoxPass.Text;

            // Check if the input is a numeric value
            if (!int.TryParse(inputPin, out int pin))
            {
                txtBoxPass.Text = ""; // clear the textbox
                txtBoxConfirm.Text = "";
                MessageBox.Show("Please enter a numeric pin.");
                return;
            }

            // Check if the pin is at least 6 digits long
            if (inputPin.Length < 6)
            {
                txtBoxPass.Text = ""; // clear the textbox
                txtBoxConfirm.Text = "";
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
                txtBoxPass.Text = ""; // clear the textbox
                txtBoxConfirm.Text = "";
                MessageBox.Show("Pin should not contain sequential digits.");
                return;
            }

            if (isRepeated)
            {
                txtBoxPass.Text = ""; // clear the textbox
                txtBoxConfirm.Text = "";
                MessageBox.Show("Pin should not contain repeated digits.");
                return;
            }

            // If the pin passes all checks, it is valid
            MessageBox.Show("Pin is valid.");

            if (!IsValidEmail(txtBoxEmail.Text))
            {
                txtBoxEmail.Text = "";
                MessageBox.Show("Invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtBoxConfirm.Text != string.Empty || txtBoxPass.Text != string.Empty || txtBoxEmail.Text != string.Empty)
                {
                    if (txtBoxPass.Text == txtBoxConfirm.Text)
                    {
                        // Set up parameters
                        string password = txtBoxPass.Text;
                        byte[] salt = GenerateSalt();
                        int iterations = 10000;
                        int keySize = 256;

                        // Generate encryption key
                        byte[] encryptionKey = GenerateEncryptionKey(password, salt, iterations, keySize);

                        // Convert input string to bytes
                        string input = "Hello, world!";
                        byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                        // Encrypt input bytes using encryption key
                        byte[] encryptedBytes = Encrypt(inputBytes, encryptionKey);

                        // Convert encrypted bytes to base64 string
                        string encryptedString = Convert.ToBase64String(encryptedBytes);

                        /*
                         * Decrypt
                        // Decrypt encrypted bytes using encryption key
                        byte[] decryptedBytes = Decrypt(encryptedBytes, encryptionKey);

                        // Convert decrypted bytes to string
                        string decryptedString = Encoding.UTF8.GetString(decryptedBytes);*/


                        cmd = new SqlCommand("select * from LoginTable where Email='" + txtBoxEmail.Text + "'", cn);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            dr.Close();
                            MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            dr.Close();
                            cmd = new SqlCommand("insert into LoginTable values(@Email,@Password)", cn);
                            cmd.Parameters.AddWithValue("email", txtBoxEmail.Text);
                            cmd.Parameters.AddWithValue("password", txtBoxPass.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
