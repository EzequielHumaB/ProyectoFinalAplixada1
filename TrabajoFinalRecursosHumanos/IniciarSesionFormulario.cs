using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Entidades;

namespace TrabajoFinalRecursosHumanos
{
    public partial class IniciarSesionFormulario : Form
    {
        private static RSAParameters ClavePrivada;
        private static RSAParameters ClavePublica;
        public IniciarSesionFormulario()
        {
            InitializeComponent();
        }


        static void GenerarLlave()
        {
            using (var rsa= new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                ClavePublica = rsa.ExportParameters(false);
                ClavePrivada = rsa.ExportParameters(true);
            }

        }

        static byte[] Encriptar(byte[] imput)
        {
            byte[] encriptado;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(ClavePublica);
                encriptado = rsa.Encrypt(imput, true);
            }
            return encriptado;
        }
        static byte[] DesEncriptar(byte[] imput)
        {
            byte[] encriptado;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(ClavePrivada);
                encriptado = rsa.Decrypt(imput, true);
            }
            return encriptado;
        }



        public string Encriptar(string EncriptarClave)
        {
            string resultado = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(EncriptarClave);
            resultado = Convert.ToBase64String(encryted);
            return resultado;
        }

        public string DesEncriptar(string cadenaDesencriptada)
        {
            string resultado = string.Empty;
            byte[] decryted = Convert.FromBase64String(cadenaDesencriptada);
            resultado = System.Text.Encoding.Unicode.GetString(decryted);

            return resultado;
        }

      

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            GenerarLlave();
            byte[] encriptado = Encriptar(Encoding.UTF8.GetBytes(ClaveUsuarioTextBox.Text));
            byte[] desencriptado = DesEncriptar(encriptado);
            Encriptadolabel.Text = BitConverter.ToString(encriptado).Replace("-"," ");
            Desencriptadolabel.Text = Encoding.UTF8.GetString(desencriptado);
        }
    }
}
