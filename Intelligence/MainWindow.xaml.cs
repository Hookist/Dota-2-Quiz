using Intelligence.entyty;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace Intelligence {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Global global;
        Model1 mod;
        bool end = false;
        public MainWindow() {
            InitializeComponent();
            mod = new Model1();
            StartCategory(1);





        }
        void StartCategory(int idCategory) {

            global = new Global(Opros);

            foreach (var quest in mod.Questions) {

                if (idCategory == quest.category_id) {

                    int id = quest.id;
                    int ball = Convert.ToInt32(quest.value);
                    string Queststr = quest.question;
                    List<string> answstr = new List<string>();
                    List<bool> answbool = new List<bool>();

                    foreach (var answ in quest.Answers) {
                        answstr.Add(answ.text);
                        answbool.Add(answ.is_true);
                    }
                    global.addVopros(new OneVopros(ball, id, Queststr, answstr, answbool));
                }
            }
            global.Start();
            CountQuest.Content = global.GetNow() + "/" + global.GetCount();
            TrueQuests.Content = global.GetTrue() + "/" + global.GetNow();
        }
        public void End() {
            Opros.Children.Add(new Label() {Content="Вы ответили на "+ global.GetCount()+" вопросов" ,Foreground = Brushes.White});
            Opros.Children.Add(new Label() { Content = "Вы ответили правильно на " + global.GetTrue() + " вопросов", Foreground = Brushes.White });
            Opros.Children.Add(new Label() { Content = "Вы получили балов " + global.GetNowBal()+"/" + global.GetMaxBall(), Foreground = Brushes.White });
        }
        private void Ok_Vopros(object sender, RoutedEventArgs e) {
            global.StartOtvet();
            CountQuest.Content = global.GetNow() + "/" + global.GetCount(); 
            TrueQuests.Content = global.GetTrue() + "/" + global.GetNow();

            if (global.IsEnd() == true && end == false) {
                End();
                end = true;
            }

        }

        private void Change_Click(object sender, RoutedEventArgs e) {
            Menu m = new Menu();
            m.Visibility= Visibility.Visible;
            this.Close();
        }
    }
}
