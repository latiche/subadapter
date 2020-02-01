using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SubAdapter
{

    public partial class MainWindow : Form
    {

        //à faire en v2 : if tout le dossier sélectionné, faire un parallel for each sur tous les fr.srt du dossier
        // à faire en v2 : if toutes les langues sélectionné, faire un parallel for each sur tous les srt du dossier avec le même nom d'épisode (donc parser le filename)
        // à faire en v2 : if toutes les langues sélectionné et tout le dossier sélectionné , faire un parallel for each sur tous les srt du dossier
        /// <summary>
        /// exemple de sous titre  :
        /// 
//1
//00:02:11,548 --> 00:02:12,966
//Arrêtez de bouger.

//2
//00:02:13,967 --> 00:02:15,093
//Arrêtez.

//3
//00:02:17,763 --> 00:02:18,931
//C'est derrière.

//4
//00:02:24,019 --> 00:02:24,937
//Tu m'expliques ?

        /// 
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();
        }


        string filePath = string.Empty;
        string fileName = string.Empty;
        bool openFileOK = false;
        private void btn_browse_Click(object sender, EventArgs e)
        {
            ParserSrt();

            textBox1.Text = filePath;
        }

        private bool ParserSrt()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "Z:\\downloads\\tv\\Big Little Lies\\Big.Little.Lies.S01E01.Somebodys.Dead.1080p.AMZN.WEBRip.DD5.1.x264-NTb";
                openFileDialog.Filter = "srt files (*.srt)|*.srt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileOK = true;
                    fileName = openFileDialog.FileName;
//                    filePath = DirectoryInfo.Path; // voir cmt récupérer le chemin sélectionner

                }
                else
                {
                    return openFileOK = false;
                }
            }
        }
        private void ParserSrtAvecAnalyseLigne()
        {
            if (openFileOK == true)
                {
                    using (StreamReader reader = new StreamReader()) // voir cmt donner le filestream
                    {
                        try
                        {
                            string line = null;
                            while ( (line = reader.ReadLine()) != null )
                          
                            { 
                            // todo
                            // si chaine vide je change de ss titre, à ce moment je vais chercher l'id suivant
                            // si id alors chaine suivante = date début, puis "  -->   " date fin, puis texte jusqu'à chaine vide

                            // datetime.parse pour décaler (ou parseexact) -- celui qui prend un formatteur en parametre
                            // DateTime.Parse(string, provider) .AddSecond
                            // créer un objet sstitre qui contient un id, une datedébut, datefin, texte

                            //to do textbox nb de scondes de décalage


                            }
                            
                           
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message != null)
                                textBox3.Visible = true;
                            textBox3.Text = ex.Message;
                        }
                    }
                }
            else
                {
                MessageBox.Show("FichierMalImporté");
                }
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime ts = DateTime.Now;
            btn_browse.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            checkBox1.Enabled = false;
            textBox1.Enabled = false;
            button2.Enabled = false;


            ParserSrtAvecAnalyseLigne();



                textBox2.Visible = true;
            textBox2.Text = string.Format("Temps mis : {0} ms", DateTime.Now.Subtract(ts).TotalMilliseconds);
            button3.Visible = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox2.Visible = false;
            button3.Visible = false;
            btn_browse.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            checkBox1.Enabled = true;
            textBox1.Enabled = true;
            button2.Enabled = true;

        }
    }
        
}
