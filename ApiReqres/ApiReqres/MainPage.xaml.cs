using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ApiReqres
{
	public partial class MainPage : ContentPage
	{
        static int page;
        public MainPage()
		{
			InitializeComponent();
            ClickAhead(null, null);
        }
        private void GetAheadListUsers()
        {
            List<User> users = new List<User>();
            var reqresApi = RestService.For<IReqresApi>("https://reqres.in/api");
            for (int i = page * 3 + 1; i <= page * 3 + 3; i++)
            {
                var apiResult = reqresApi.GetUser(i).Result;
                User user = new User(apiResult);
                users.Add(user);
            }
            listApi.ItemsSource = users;
            page++;
        }
        private void GetBackListUsers()
        {
            page = page - 2;
            List<User> users = new List<User>();
            var reqresApi = RestService.For<IReqresApi>("https://reqres.in/api");
            for (int i = page * 3 + 1; i <= page * 3 + 3; i++)
            {
                var apiResult = reqresApi.GetUser(i).Result;
                User user = new User(apiResult);
                users.Add(user);
            }
            listApi.ItemsSource = users;
            page++;
        }
        public interface IReqresApi
        {
            [Get("/users/{user}")]
            Task<String> GetUser(int user);
        }
        private void ClickBack(object sender, EventArgs e)
        {
            State.TextColor = Color.Default;
            State.Text = "Загрузка";
            try
            {
                GetBackListUsers();
                State.Text = "Выполнено";
                if (page < 2)
                    ButtonBack.IsEnabled = false;
            }
            catch (Exception ex)
            {
                State.Text = "Ошибка при загрузки";
                State.TextColor = Color.Accent;
            }
        }
        private void ClickAhead(object sender, EventArgs e)
        {
            State.TextColor = Color.Default;
            State.Text = "Загрузка";
            try
            {
                GetAheadListUsers();
                State.Text = "Выполнено";
                ButtonBack.IsEnabled = true;
            }
            catch (Exception ex)
            {
                State.Text = "Ошибка при загрузки";
                State.TextColor = Color.Accent;
            }
        }
    }
}
