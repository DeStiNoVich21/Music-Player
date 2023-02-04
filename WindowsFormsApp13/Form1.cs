using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;
using System.IO;
namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            updater();
        }
        private int i = 0;
        private int a = 0;
        WMPLib.WindowsMediaPlayer Player;
        WMPLib.WindowsMediaPlayer winmp = new WMPLib.WindowsMediaPlayer();
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        int selectedindex;
        private void updater()
        {
            //clearing listbox
            listBox1.Items.Clear();
         
            //filling it
            foreach (var file in Directory.EnumerateFiles(@"C:\Users\User\source\repos\WindowsFormsApp13\WindowsFormsApp13\Music"))
            {
                //Adding music in files to listview
                string extension = Path.GetExtension(file);
                listBox1.Items.Add(Path.GetFileName(file));
              
            }

            //filling it

        }
        private void droid()
            {
                i = 1;
                // choosen music name
                string name;
                if (i == 1)
                {
                    name = listBox1.SelectedItem.ToString();

                    //Choose music

                    winmp.URL = @"C:\Users\User\source\repos\WindowsFormsApp13\WindowsFormsApp13\Music\" + name + "";
                    // set the current and max duration
               

                    //actually play it
                    winmp.controls.play();
                    //bind to the progressbar
                   
             
                    //actually start it
                    timer1.Start();
                guna2HtmlLabel4.Text = winmp.currentMedia.durationString;
                    
                    selectedindex = listBox1.SelectedIndex;
                    guna2CircleButton1.Text = "[]";

                }
                else
                {
                    winmp.controls.stop();
                    i = 1;
                    timer1.Stop();
                    guna2CircleButton1.Text = "||";
                }
            }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            winmp.controls.currentPosition -= 0.05;
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            // changing playing mode
            a++;
            if (a == 1)
            {
               guna2CircleButton4.Text = "Next";


            }
            if (a == 2)
            {
                guna2CircleButton4.Text = "Retry";

            }
            if (a == 3)
            {
                guna2CircleButton4.Text = "Random";


            }
            if (a == 4)
            {
                a = 1;
                guna2CircleButton4.Text = "Next";


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            guna2HtmlLabel3.Text = winmp.controls.currentPositionString;
       

            // place that allows to music playing mod like reapet or repeating the list
            if (i == 0)
            {

            }
            else
            {
                if (winmp.controls.currentPosition==winmp.currentMedia.duration)
                {
                    if (a == 1)
                    {
                        guna2CircleButton4.Text = "Next";
                        listBox1.SelectionMode = SelectionMode.One;
                        listBox1.SetSelected(selectedindex + 1, true);
                        if (selectedindex > listBox1.Items.Count)
                        {
                            selectedindex = 0;
                        }
                       

                        droid();

                    }
                    if (a == 2)
                    {
                        guna2CircleButton4.Text = "Retry";
                        listBox1.SelectionMode = SelectionMode.One;
                        listBox1.SetSelected(selectedindex, true);
                        if (selectedindex > listBox1.Items.Count)
                        {
                            selectedindex = 0;
                        }
                     

                        droid();
                    }
                    if (a == 3)
                    {
                        guna2CircleButton4.Text = "Random";
                        listBox1.SelectionMode = SelectionMode.One;
                        Random rnd = new Random();
                        selectedindex = rnd.Next(0, listBox1.Items.Count);
                        listBox1.SetSelected(selectedindex, true);
                        if (selectedindex > listBox1.Items.Count)
                        {
                            selectedindex = 0;
                        }
                    
                        droid();

                    }
                }
            }
          }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            winmp.controls.currentPosition += 5;
        }

        private void guna2CircleButton5_Click(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox1.SetSelected(selectedindex + 1, true);
            droid();
        }

        private void guna2CircleButton6_Click(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.One;
            listBox1.SetSelected(selectedindex - 1, true);
            droid();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Playing music on selection30
            droid();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Philter for files
            openFileDialog1.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV";
            saveFileDialog1.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV";
            string[] MoveFrom = openFileDialog1.FileNames;

            string[] FileName = openFileDialog1.SafeFileNames;

            string MoveTo = @"C:\Users\User\source\repos\WindowsFormsApp10\WindowsFormsApp10\Music";

            openFileDialog1.Multiselect = true;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (string _file in openFileDialog1.FileNames)
                    {
                        FileInfo fi = new FileInfo(_file);
                        File.Move(_file, Path.Combine(MoveTo, fi.Name));

                    }
                    MessageBox.Show("Elements succesfully added");
                }
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

            updater();
        
    }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string name = listBox1.SelectedItem.ToString();
                File.Delete(@"C:\Users\User\source\repos\WindowsFormsApp10\WindowsFormsApp10\Music\" + name + "");
                updater();
            }

            catch (System.IO.IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
