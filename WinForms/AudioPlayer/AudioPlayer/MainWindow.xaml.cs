using Microsoft.Win32;using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AudioPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MusicList PlayList;
        public bool isPlayed = false;
        public WMPLib.WindowsMediaPlayer Player;
        public TagLib.File file;
        public DispatcherTimer timer;
        public int Track_Index;
        public TagLib.IPicture picture;

        public MainWindow()
        {
            InitializeComponent();
            PlayList = new MusicList();
            Player = new WMPLib.WindowsMediaPlayer();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
        }


        private void Add_Song(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV";

            string filepath=null;
            if(open.ShowDialog() == true) 
            {
                filepath = open.FileName;
                PlayList.playlist.Add(filepath);
                Track_Index = 0;
                if (PlayList.playlist.Count == 1) { Player.URL = PlayList.playlist[0]; }
            }

            if (!string.IsNullOrEmpty(filepath)) 
            {
                file = TagLib.File.Create(filepath);
                string track = file.Tag.Title + " by " + file.Tag.FirstPerformer;

                Author_textbox.Text = Author_textbox.Text + "  " + file.Tag.FirstPerformer;
                Title_textbox.Text = Title_textbox.Text + "  " + file.Tag.Title;

                //try 
                //{
                //    if (file.Tag.Pictures.Length == 0) 
                //    {
                //        MessageBox.Show("asd");
                //        picture = file.Tag.;
                //        MemoryStream stream = new MemoryStream(picture.Data.Data);
                //        stream.Seek(0, SeekOrigin.Begin);

                //        BitmapImage bitmap = new BitmapImage();
                //        bitmap.BeginInit();
                //        bitmap.StreamSource = stream;
                //        bitmap.EndInit();

                //        Cover_Image.Source = bitmap;
                //    }
                //}
                //catch(Exception ex) { MessageBox.Show(ex.Message); }

                playlistbox.Items.Add(track);
                file.Dispose();
            }
            
        }

        private void Delete_Song(object sender, RoutedEventArgs e)
        {
            if(playlistbox.SelectedIndex != -1) 
            {
                int index = playlistbox.SelectedIndex;
                playlistbox.Items.RemoveAt(index);
                PlayList.playlist.RemoveAt(index);
            }
        }

        private void Play_or_Pause_btn(object sender, RoutedEventArgs e)
        {

            if (PlayList.playlist.Count > 0) 
            {
                
                if (isPlayed)
                {
                    isPlayed = false;
                    Play.Visibility = Visibility.Visible;
                    Pause1.Visibility = Visibility.Hidden;
                    Pause2.Visibility = Visibility.Hidden;
                    Player.controls.pause();
                    timer.Stop();

                    
                }
                else
                {
                    isPlayed = true;
                    Play.Visibility = Visibility.Hidden;
                    Pause1.Visibility = Visibility.Visible;
                    Pause2.Visibility = Visibility.Visible;
                    Player.controls.play();
                          
                    int s_time = (int)file.Properties.Duration.TotalSeconds;
                    DurationSlider.Maximum = s_time;
                    DurationSlider.Minimum = 0;

                    timer.Start();
                   
                }
            }
        }

        private void VolumeSlider_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            Player.settings.volume = (int)VolumeSlider.Value;
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DurationSlider.Value += 1;
        }

        private void Previos_Click(object sender, RoutedEventArgs e)
        {
            if(Track_Index - 1 >= 0) 
            {
                Track_Index--;
                Player.URL = PlayList.playlist[Track_Index];
                file = TagLib.File.Create(PlayList.playlist[Track_Index]);
                Author_textbox.Text = Author_textbox.Text + "  " + file.Tag.FirstPerformer;
                Title_textbox.Text = Title_textbox.Text + "  " + file.Tag.Title;

                picture = file.Tag.Pictures[0];
                MemoryStream stream = new MemoryStream(picture.Data.Data);
                stream.Seek(0, SeekOrigin.Begin);

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.EndInit();

                Cover_Image.Source = bitmap;
                file.Dispose();
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (Track_Index + 1 <= PlayList.playlist.Count)
            {
                Track_Index++;
                Player.URL = PlayList.playlist[Track_Index];
                file = TagLib.File.Create(PlayList.playlist[Track_Index]);
                Author_textbox.Text = Author_textbox.Text + "  " + file.Tag.FirstPerformer;
                Title_textbox.Text = Title_textbox.Text + "  " + file.Tag.Title;

                //picture = file.Tag.Pictures[0];
                //MemoryStream stream = new MemoryStream(picture.Data.Data);
                //stream.Seek(0, SeekOrigin.Begin);

                //BitmapImage bitmap = new BitmapImage();
                //bitmap.BeginInit();
                //bitmap.StreamSource = stream;
                //bitmap.EndInit();

                //Cover_Image.Source = bitmap;
                //file.Dispose();
            }
        }
    }
}
