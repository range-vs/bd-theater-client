using CursMaryTwoSemestry.CombinedDataBase;
using CursMaryTwoSemestry.DatabaseTable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursMaryTwoSemestry
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitMenu();
        }

        private void InitMenu()
        {
            string[] names = new string[] { "Актёры", "Занятость", "Роли", "Звания" };
            for (int i = 0;i < names.Length;i++)
            {
                var elemMenu = new ToolStripMenuItem(names[i]);
                elemMenu.Tag = i;
                elemMenu.Click += (sender, e) =>
                {
                    int? k = ((sender as ToolStripMenuItem).Tag as int?);
                    CreateTable(k.Value).ShowDialog();
                };
                MenuAllData.DropDownItems.Add(elemMenu);
            }
            string[] namesCombined = new string[] { "Все актёры и их звания", "Все актёры и их роли", "Все актёры и их спектакли" };
            for (int i = 0; i < namesCombined.Length; i++)
            {
                var elemMenu = new ToolStripMenuItem(names[i]);
                elemMenu.Tag = i;
                elemMenu.Click += (sender, e) =>
                {
                    int? k = ((sender as ToolStripMenuItem).Tag as int?);
                    CreateUniqueDatabase(k.Value).ShowDialog();
                };
                MenuCombinedData.DropDownItems.Add(elemMenu);
            }
        }

        private Form CreateTable(int i)
        {
            List<Form> forms = new List<Form>()
            {
                new Actors(),
                new Employments(),
                new Plays(),
                new Statuses()
            };
            try
            {
                return forms[i];
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private Form CreateUniqueDatabase(int i)
        {
            string[] query = new string[]
            {
                "SELECT actor.last_name, actor.first_name, actor.second_name, [status].title FROM actor, [status] WHERE actor.status_id = [status].id;",
                "SELECT actor.last_name, actor.first_name, actor.second_name, employment.[role] FROM actor, employment WHERE actor.id = employment.actor_id;",
                "SELECT actor.last_name, actor.first_name, actor.second_name, play.[name], play.genre, play.date_of_premiere, play.budget FROM actor, employment, play WHERE actor.id = employment.actor_id AND employment.play_id = play.id;"
            };
            List<string[]> names = new List<string[]>
            {
                new string[]{"Фамилия", "Имя", "Отчество", "Статус"},
                new string[]{"Фамилия", "Имя", "Отчество", "Роль"},
                new string[]{"Фамилия", "Имя", "Отчество", "Наименование спектакля", "Жанр", "Дата премьеры", "Бюджет"}
            };
            try
            {
                return new Request(names[i], query[i]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private void AboutShow(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
