using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculationGame2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        List<Button> _buttons = new List<Button>();
        GamePageViewModel _viewModel;
        Timer timer;


        bool _gameOver = false;


        public GamePage()
        {
            InitializeComponent();

            Game game = new Game();
            _viewModel = new GamePageViewModel(game);

            BindingContext = _viewModel;

            NavigationPage.SetHasNavigationBar(this, false);


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Button button = new Button();
                    button.Text = String.Format("{0}-{1}", i, j);
                    button.Clicked += Button_Clicked;

                    GridButtons.Children.Add(button, i, j);
                    _buttons.Add(button);
                }
            }

            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;

            timer.Start();
            UpdateSample();
        }

        /// <summary>
        /// Функция создает и обновляет пример
        /// </summary>
        public void UpdateSample()
        {
            _viewModel.UpdateCurrentSample();

            int countVariants = Math.Min(15, 3 + _viewModel.Game.Level / 10);

            List<int> variants = _viewModel.Game.CurrentSample.GetVariants(countVariants);

            List<int> randomIndexes = new List<int>();

            Random random = new Random();

            while(randomIndexes.Count < variants.Count)
            {
                int index = random.Next(0, _buttons.Count);
                if (randomIndexes.Contains(index))
                    continue;
                randomIndexes.Add(index);
            }

            _buttons.ForEach(b => b.IsVisible = false);

            for (int i = 0; i < randomIndexes.Count; i++)
            {
                _buttons[randomIndexes[i]].Text = variants[i].ToString();
                _buttons[randomIndexes[i]].IsVisible = true;
            }
        }

        public void GameOver()
        {
            timer.Stop();
            timer.Dispose();

            Navigation.PushAsync(new FinalPage
                (new FinalPageViewModel(_viewModel.Game.Score, _viewModel.AllGameTime, _viewModel.MaxLevel)));

            return;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_gameOver)
                return;

            if (_viewModel.CheckIsGameOver())
            {
                _gameOver = true;

                MainThread.BeginInvokeOnMainThread(() => GameOver());
            }
            else
                _viewModel.UpdateGameTimer();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            int answer = Convert.ToInt32(((Button)sender).Text);

            bool win = _viewModel.ToAnswer(answer);

            if (win)
                UpdateSample();
            else
                DisplayAlert("", "INCORRECT (-5 sec.) !!!", "continue");
                
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}